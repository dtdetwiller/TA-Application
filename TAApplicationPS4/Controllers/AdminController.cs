/**
 * Author:    Daniel Detwiller
 * Partner:   None
 * Date:      12-10-2021
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Daniel Detwiller - This work may not be copied for use in Academic Coursework.
 *
 * I, Daniel Detwiller, certify that I wrote this code from scratch and did 
 * not copy it in part or whole from another source.  Any references used 
 * in the completion of the assignment are cited in my README file and in
 * the appropriate method header.
 *
 * File Contents
 *
 *    This is the admin controller
 */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TAApplicationPS4.Areas.Identity.Data;
using TAApplicationPS4.Data;
using TAApplicationPS4.Models;

namespace TAApplicationPS4.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly UserManager<TAUser> _um;
        private readonly RoleManager<IdentityRole> _rm;
        private readonly TA_DB _context;

        public AdminController(ILogger<AdminController> logger, TA_DB context, UserManager<TAUser> um, RoleManager<IdentityRole> rm)
        {
            _logger = logger;
            _um = um;
            _rm = rm;
            _context = context;
        }

        /// <summary>
        /// This is the Index controller, the index page displays the admin datatable.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            

            return View();
        }

        /// <summary>
        /// This end point returns a iew containing the controls to query the database and display the charts.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> EnrollmentTrends()
        {
            return View();
        }

        /// <summary>
        /// This method gets all the enrollment data from the database and sends it to the view.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetEnrollmentData(string startDate, string endDate, string course)
        {
            var startDateArr = startDate.Split("-");
            var startYear = int.Parse(startDateArr[0]);
            var startMonth = int.Parse(startDateArr[1]);
            var startDay = int.Parse(startDateArr[2]);
            
            var endDateArr = endDate.Split("-");
            var endYear = int.Parse(endDateArr[0]);
            var endMonth = int.Parse(endDateArr[1]);
            var endDay = int.Parse(endDateArr[2]);

            DateTime start = new DateTime(startYear, startMonth, startDay);
            DateTime end = new DateTime(endYear, endMonth, endDay);

            int courseNumber = int.Parse(course.Split(" ")[1]);
            var courses = _context.Courses.ToList();
            var courseID = 0;

            foreach (Course c in courses)
            {
                if (c.CourseNumber == courseNumber)
                    courseID = c.CourseID;
            }


            var enrollments = _context.EnrollmentOverTime.ToList();
            List<EnrollmentOverTime> sortedEnrollments = new List<EnrollmentOverTime>();
            
            foreach (EnrollmentOverTime en in enrollments)
            {
                if (courseID == en.CourseID && en.EnrollmentDate >= start && en.EnrollmentDate <= end)
                {
                    sortedEnrollments.Add(en);
                }
            }

            sortedEnrollments.Sort((x, y) => DateTime.Compare(x.EnrollmentDate, y.EnrollmentDate));

            List<int> validEnrollments = new List<int>();
            foreach (EnrollmentOverTime en in sortedEnrollments)
                validEnrollments.Add(en.Enrollment);

            return Ok(new
            {
                message = "This worked",
                returnedEnrollments = Json(validEnrollments)
            });
        }

        [HttpPost]
        public async Task<IActionResult> changeRole(string userid, string role, string elementID)
        {
            if (userid == null)
                return BadRequest("userid was null.");

            TAUser user = await _um.FindByIdAsync(userid);
            
            // Remove user from role if already in it, otherwise add to role.
            if (await _um.IsInRoleAsync(user, role))
                await _um.RemoveFromRoleAsync(user, role);
            else
                await _um.AddToRoleAsync(user, role);

            return Ok(new { message = "This worked",
            input = $"{userid}, {role}, {elementID}"});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
