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

        /// <summary>
        /// This method creates singular table names in the DbContext
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().ToTable("Application");
        }
    }
}
