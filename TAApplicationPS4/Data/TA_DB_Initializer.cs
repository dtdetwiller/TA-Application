using System;
using System.Linq;
using TAApplicationPS4.Models;

namespace TAApplicationPS4.Data
{
    public class TA_DB_Initializer
    {

        public static void Initialize(TA_DB db)
        {
            // This makes sure that the database has been created.
            db.Database.EnsureCreated();

            if (db.Applications.Any())
                return; // DB has been seeded.

            var applicaitons = new Application[]
            {
                // Create seeded data
                new Application{Name="Daniel Detwiller" }
            };

            foreach (Application a in applicaitons)
                db.Applications.Add(a);

            // Save the changes to the database.
            db.SaveChanges();
        }
    }
}
