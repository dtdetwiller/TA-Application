using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using TAApplicationPS4.Data;
using TAApplicationPS4.Models;

namespace TAApplicationPS4.Areas.Identity.Data
{
    public class SeedUsersRolesDB
    {

        public static async Task InitializeAsync(TAUsersRolesDB db, UserManager<TAUser> um, RoleManager<IdentityRole> rm)
        {
            // This makes sure that the database has been created.
            db.Database.EnsureCreated();

            // Create roles, create async the roles
            IdentityRole[] roles = new IdentityRole[]
            {
                new IdentityRole{Name="Administrator"},
                new IdentityRole{Name="Professor"},
                new IdentityRole{Name="Applicant"}
            };

            foreach (var r in roles)
            {
                await rm.CreateAsync(r);
            }

            // Create users
            TAUser[] users = new TAUser[]
            {
                new TAUser{UserName="admin@utah.edu", Email="admin@utah.edu", EmailConfirmed=true},
                new TAUser{UserName="professor@utah.edu", Email="professor@utah.edu", EmailConfirmed=true},
                new TAUser{UserName="u0000000@utah.edu", Email="u0000000@utah.edu", EmailConfirmed=true},
                new TAUser{UserName="u0000001@utah.edu", Email="u0000001@utah.edu", EmailConfirmed=true},
                new TAUser{UserName="u0000002@utah.edu", Email="u0000002@utah.edu", EmailConfirmed=true}

            };

            foreach (var u in users)
            {
                await um.CreateAsync(u, "123ABC!@#def");
            }

            // Assign roles to the users.
            foreach (TAUser u in users)
            {
                if (u.UserName == "admin@utah.edu")
                {
                    await um.AddToRoleAsync(u, "Administrator");
                }
                else if (u.UserName == "professor@utah.edu")
                {
                    await um.AddToRoleAsync(u, "Professor");
                }
                else
                {
                    await um.AddToRoleAsync(u, "Applicant");
                }
            }

            // Save the changes to the database.
            db.SaveChanges();
        }
    }
}
