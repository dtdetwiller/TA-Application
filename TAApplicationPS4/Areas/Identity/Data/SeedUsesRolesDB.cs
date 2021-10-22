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

        public static async Task InitializeAsync(TAUsersRolesDB db, TA_DB TAdb, UserManager<TAUser> um, RoleManager<IdentityRole> rm)
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
                // Creates an application for these users.
                else if (u.UserName == "u0000001@utah.edu" || u.UserName == "u0000002@utah.edu")
                {
                    var app = new Application
                    {
                        UserID = u.Id,
                        Name = u.UserName,
                        uID = "u0000000",
                        Program = "CS",
                        GPA = 3.7f,
                        Hours = 20,
                        Phone = "(603) 717-5221",
                        Email = u.Email,
                        Degree = "BS",
                        LinkedInURL = "https://www.linkedin.com/",
                        PersonalStatement = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."
                    };

                    TAdb.Applications.Add(app);
                    await um.AddToRoleAsync(u, "Applicant");
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
