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
            //Debug.WriteLine(monday);
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

            Debug.WriteLine(monday);
            timeSlot.Monday = monday;
            //Debug.WriteLine(timeSlot.Monday);
            timeSlot.Tuesday = tuesday;
            Debug.WriteLine(tuesday);
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
