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
using TAApplicationPS4.Models;

namespace TAApplicationPS4.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly UserManager<TAUser> _um;
        private readonly RoleManager<IdentityRole> _rm;

        public AdminController(ILogger<AdminController> logger, UserManager<TAUser> um, RoleManager<IdentityRole> rm)
        {
            _logger = logger;
            _um = um;
            _rm = rm;
        }

        /// <summary>
        /// This is the Index controller, the index page displays the admin datatable.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View();
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
