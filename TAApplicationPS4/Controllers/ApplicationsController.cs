/**
 * Author:    Daniel Detwiller
 * Partner:   None
 * Date:      09-29-2021
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
 *    This is the scaffolded Applicaitons controller.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TAApplicationPS4.Data;
using TAApplicationPS4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using TAApplicationPS4.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace TAApplicationPS4.Controllers
{
    [Authorize]
    public class ApplicationsController : Controller
    {
        private readonly TA_DB _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<TAUser> _um;
        private readonly RoleManager<IdentityRole> _rm;

        public ApplicationsController(TA_DB context, IConfiguration configuration, UserManager<TAUser> um, RoleManager<IdentityRole> rm)
        {
            _context = context;
            _um = um;
            _rm = rm;
            _configuration = configuration;
        }

        public ActionResult Index()
        {
            // Get the total number of applicants
            ViewBag.totalApplicants = _context.Applications.Count();

            // Get the averge gpa of applicants
            var GPAs = _context.Applications.Where(app => app.GPA > 0f).Select(col => col.GPA).ToArray();
            float totalOfGPAs = 0.0f;
            foreach (float gpa in GPAs)
            {
                totalOfGPAs += gpa;
            }
            // Average GPA to 2 decimal places.
            ViewBag.avgGPA = (totalOfGPAs / GPAs.Length).ToString("n2");

            return View();
        }

        // GET: Applications (previously was Index)
        public async Task<IActionResult> List()
        {
            return View(await _context.Applications.ToListAsync());
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .FirstOrDefaultAsync(m => m.ID == id);

            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // GET: Applications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ID,Name,Phone,Email,Degree,Program,GPA,Hours,PersonalStatement,Semesters,LinkedInURL,Resume,CreationDate,ModificationDate")] Application application)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(application);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { application.ID });
                }
            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return View(application);
        }

        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,uID,Name,Phone,Email,Degree,Program,GPA,Hours,PersonalStatement,Semesters,LinkedInURL,Resume,CreationDate,ModificationDate")] Application application)
        {
            if (id != application.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { application.ID });
            }
            return View(application);
        }

        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (application == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return RedirectToAction(nameof(List));
            }

            try
            {
                _context.Applications.Remove(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.ID == id);
        }
    }
}
