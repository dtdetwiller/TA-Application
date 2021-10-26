/**
 * Author:    Daniel Detwiller
 * Partner:   None
 * Date:      10-25-2021
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
 *    This is the scaffolded Courses controller.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TAApplicationPS4.Areas.Identity.Data;
using TAApplicationPS4.Data;
using TAApplicationPS4.Models;

namespace TAApplicationPS4.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly TA_DB _context;
        private readonly UserManager<TAUser> _um;
        private readonly RoleManager<IdentityRole> _rm;

        public CoursesController(TA_DB context, UserManager<TAUser> um, RoleManager<IdentityRole> rm)
        {
            _context = context;
            _um = um;
            _rm = rm;
        }

        // GET: Courses
        [Authorize(Roles = "Administrator, Professor")]
        public async Task<IActionResult> List()
        {
            return View(await _context.Courses.ToListAsync());
        }

        // GET: Courses/Details/5
        [Authorize(Roles = "Administrator, Professor, Applicant")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("CourseID,Semester,Year,Title,Department,CourseNumber,Section,Description,ProfessorUNID,ProfessorName,TimeDays,Location,Credits,Enrolled,Note")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("CourseID,Semester,Year,Title,Department,CourseNumber,Section,Description,ProfessorUNID,ProfessorName,TimeDays,Location,Credits,Enrolled,Note")] Course course)
        {
            if (id != course.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(List));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        /// <summary>
        /// This gets called by JS and saves the note.
        /// </summary>
        /// <param name="elementID"></param>
        /// <param name="courseID"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SaveNote(string elementID, string courseID, string value)
        {

            if (courseID != null)
            {
                var course = await _context.Courses
                    .FirstOrDefaultAsync(m => m.CourseID == int.Parse(courseID));

                course.Note = value;
                await _context.SaveChangesAsync();
            }

            return Ok(new
            {
                message = "This worked",
                input = $"{elementID}, {courseID}, {value}"
            });
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseID == id);
        }
    }
}
