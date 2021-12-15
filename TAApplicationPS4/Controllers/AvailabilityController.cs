/**
 * Author:    Daniel Detwiller
 * Partner:   None
 * Date:      11-22-2021
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
 *    This is the availability controller.
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
    [Authorize]
    public class AvailabilityController : Controller
    {
        private readonly ILogger<AvailabilityController> _logger;
        private readonly TA_DB _context;
        private readonly UserManager<TAUser> _um;
        private readonly RoleManager<IdentityRole> _rm;

        public AvailabilityController(TA_DB context, ILogger<AvailabilityController> logger, UserManager<TAUser> um, RoleManager<IdentityRole> rm)
        {
            _context = context;
            _logger = logger;
            _um = um;
            _rm = rm;
        }

        /// <summary>
        /// This is the Index controller
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            // Get this current users name
            ViewBag.name = _um.GetUserName(this.User);

            // Get the timeslot for this user
            var timeSlots = _context.TimeSlots.ToList();
            var userid = _um.GetUserId(this.User);

            ViewBag.userid = userid;
            TimeSlots timeSlot = new();
            bool flag = false;

            foreach (TimeSlots t in timeSlots)
            {
                if (t.UserID == userid)
                {
                    timeSlot = t;
                    flag = true;
                    break;
                }
            }

            if (!flag)
                return View();

            return View(timeSlot);
        }

        /// <summary>
        /// Gets the selected time slots from the javascript
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetSchedule(string userid, string monday, string tuesday, string wednesday, string thursday, string friday)
        {
            var timeSlots = _context.TimeSlots.ToList();
            TimeSlots timeSlot = new();

            foreach (TimeSlots t in timeSlots)
            {
                if (t.UserID == userid)
                {
                    timeSlot = t;
                    break;
                }
            }

            timeSlot.Monday = monday;
            timeSlot.Tuesday = tuesday;
            timeSlot.Wednesday = wednesday;
            timeSlot.Thursday = thursday;
            timeSlot.Friday = friday;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "This worked",
                input = $"{userid}, {monday}, {tuesday}, {wednesday}, {thursday}, {friday}"
            });
        }
    }
}
