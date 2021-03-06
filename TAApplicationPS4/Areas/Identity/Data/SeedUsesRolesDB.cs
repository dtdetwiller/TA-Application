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
 *    This is the UserRoles database initializer class where all the starting data is seeded.
 */

using Microsoft.AspNetCore.Identity;
using System;
using System.Diagnostics;
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

            if (db.Roles.Any())
                return;

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

            if (db.Users.Any())
                return;

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


                if (u.UserName == "u0000000@utah.edu")
                {
                    var timeSlot = new TimeSlots()
                    {
                        UserID = u.Id
                    };

                    var timeSlots = TAdb.TimeSlots.ToList();
                    Debug.WriteLine("Test 11111111");

                    // seed 8:00am to noon
                    timeSlot.Monday = "YYYYYYYYYYYYYYYYNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN";
                    timeSlot.Friday = "YYYYYYYYYYYYYYYYNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN";

                    // seed noon to 5:00pm
                    timeSlot.Tuesday = "NNNNNNNNNNNNNNNNYYYYYYYYYYYYYYYYYYYYNNNNNNNNNNNN";
                    timeSlot.Thursday = "NNNNNNNNNNNNNNNNYYYYYYYYYYYYYYYYYYYYNNNNNNNNNNNN";

                    TAdb.TimeSlots.Add(timeSlot);
                }
                else
                {
                    // Initialize this users time slots
                    var timeSlot = new TimeSlots
                    {
                        UserID = u.Id
                    };

                    TAdb.TimeSlots.Add(timeSlot);
                }
            }

            // Save the changes to the database.
            TAdb.SaveChanges();
            db.SaveChanges();
        }
    }
}
