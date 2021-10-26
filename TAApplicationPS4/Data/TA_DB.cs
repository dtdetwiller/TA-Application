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
 *    This is the database context.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAApplicationPS4.Models;
using Microsoft.EntityFrameworkCore;

namespace TAApplicationPS4.Data
{
    public class TA_DB : DbContext
    {

        public TA_DB(DbContextOptions<TA_DB> options) : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Course> Courses { get; set; }

        /// <summary>
        /// This method creates singular table names in the DbContext
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().ToTable("Applications");
            modelBuilder.Entity<Course>().ToTable("Courses");
        }
    }
}
