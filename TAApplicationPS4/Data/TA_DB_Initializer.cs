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
 *    This is the database initializer and where all the seeding is done for applications and courses.
 */

using System;
using System.Linq;
using TAApplicationPS4.Models;
using Microsoft.AspNetCore.Identity;
using TAApplicationPS4.Areas.Identity.Data;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics;

namespace TAApplicationPS4.Data
{
    public class TA_DB_Initializer
    {

        public static void Initialize(TA_DB db, TAUsersRolesDB usersRolesDB)
        {
            // This makes sure that the database has been created.
            db.Database.EnsureCreated();

            if (db.Applications.Any())
                return; // DB has been seeded.

            var applicaitons = new Application[]
            {
                // Create seeded data
                new Application{Name="Daniel Detwiller",uID="u1148322",Program="CS",GPA=3.7f,Hours=20,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="Billy Bob",uID="u2930495",Program="CS",GPA=3.2f,Hours=15,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="Michelob Ultra",uID="u0293845",Program="CS",GPA=3.9f,Hours=20,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="Malibu Wake Setter",uID="u2293342",Program="CS",GPA=4.0f,Hours=25,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="Happy Dad",uID="u118332",Program="CS",GPA=2.8f,Hours=20,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="Noah Gottlieb",uID="u9299933",Program="ENTP",GPA=3.1f,Hours=20,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="Kyle Lautt",uID="u2232232",Program="MKTH",GPA=3.3f,Hours=15,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="James Bricker",uID="u9291122",Program="ECON",GPA=3.5f,Hours=15,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="Ben Sky",uID="u0708822",Program="ETHNC",GPA=4.0f,Hours=20,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="Thomas Detwiller",uID="u1122345",Program="CHEM",GPA=3.9f,Hours=20,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."}
            };

            foreach (Application a in applicaitons)
                db.Applications.Add(a);

            // Save the changes to the database.
            db.SaveChanges();

            if (db.Courses.Any())
                return; // DB has been seeded.
            
            var courses = new Course[]
            {
                // 1400
                new Course{Semester="Spring", Year=2022, Title="Introduction to Object-Oriented Programming", Department="CS", CourseNumber=1400, Section="001",
                    Description="The second course required for students intending to major in computer science and computer engineering. Introduction to the engineering and mathematical skills required to effectively program computers, and to the range of issues confronted by computer scientists. Roles of procedural and data abstraction in decomposing programs into manageable pieces. Introduction to object-oriented programming. Extensive programming exercises that involve the application of elementary software engineering techniques.",
                ProfessorUNID="dejohnso", ProfessorName="David Johnson", TimeDays="MoWeFr 10:45AM - 11:35AM", Location="GC 1900", Credits=4, Enrolled=150, Note="Need more TAs!"},
                // 1410
                new Course{Semester="Spring", Year=2022, Title="Introduction to Object-Oriented Programming", Department="CS", CourseNumber=1410, Section="001",
                    Description="The second course required for students intending to major in computer science and computer engineering. Introduction to the engineering and mathematical skills required to effectively program computers, and to the range of issues confronted by computer scientists. Roles of procedural and data abstraction in decomposing programs into manageable pieces. Introduction to object-oriented programming. Extensive programming exercises that involve the application of elementary software engineering techniques.",
                ProfessorUNID="dejohnso", ProfessorName="David Johnson", TimeDays="MoWeFr 10:45AM - 11:35AM", Location="GC 1900", Credits=4, Enrolled=150, Note="Need more TAs!"},
                // 1420
                new Course{Semester="Spring", Year=2022, Title="Introduction to Object-Oriented Programming", Department="CS", CourseNumber=1420, Section="001",
                    Description="The second course required for students intending to major in computer science and computer engineering. Introduction to the engineering and mathematical skills required to effectively program computers, and to the range of issues confronted by computer scientists. Roles of procedural and data abstraction in decomposing programs into manageable pieces. Introduction to object-oriented programming. Extensive programming exercises that involve the application of elementary software engineering techniques.",
                ProfessorUNID="dejohnso", ProfessorName="David Johnson", TimeDays="MoWeFr 10:45AM - 11:35AM", Location="GC 1900", Credits=4, Enrolled=150, Note="Need more TAs!"},
                // 2100
                new Course{Semester="Spring", Year=2022, Title="Introduction to Algorithms & Data Structures", Department="CS", CourseNumber=2100, Section="001",
                    Description = "This course provides an introduction to the problem of engineering computational efficiency into programs. Students will learn about classical algorithms (including sorting, searching, and graph traversal), data structures (including stacks, queues, linked lists, trees, hash tables, and graphs), and analysis of program space and time requirements. Students will complete extensive programming exercises that require the application of elementary techniques from software engineering.",
                ProfessorUNID = "parker", ProfessorName = "Erin Parker", TimeDays = "TuTh 12:25PM - 1:45PM", Location = "GC 1900", Credits = 4, Enrolled = 150, Note = ""},
                //2420
                new Course{Semester="Spring", Year=2022, Title="Introduction to Algorithms & Data Structures", Department="CS", CourseNumber=2420, Section="001",
                    Description = "This course provides an introduction to the problem of engineering computational efficiency into programs. Students will learn about classical algorithms (including sorting, searching, and graph traversal), data structures (including stacks, queues, linked lists, trees, hash tables, and graphs), and analysis of program space and time requirements. Students will complete extensive programming exercises that require the application of elementary techniques from software engineering.",
                ProfessorUNID = "parker", ProfessorName = "Erin Parker", TimeDays = "TuTh 12:25PM - 1:45PM", Location = "GC 1900", Credits = 4, Enrolled = 150, Note = ""},
                // 3100
                new Course{Semester="Spring", Year=2022, Title="Software Practice", Department="CS", CourseNumber=3100, Section="001",
                    Description = "Practical exposure to the process of creating large software systems, including requirements specifications, design, implementation, testing, and maintenance. Emphasis on software process, software tools (debuggers, profilers, source code repositories, test harnesses), software engineering techniques (time management, code, and documentation standards, source code management, object-oriented analysis and design), and team development practice. Much of the work will be in groups and will involve modifying preexisting software systems.",
                ProfessorUNID = "germain", ProfessorName = "H. James De St Germain", TimeDays = "TuTh 2:00PM - 3:20PM", Location = "WEB L104", Credits = 4, Enrolled = 150, Note = ""},
                // 3200
                new Course{Semester="Spring", Year=2022, Title="Software Practice", Department="CS", CourseNumber=3200, Section="001",
                    Description = "Practical exposure to the process of creating large software systems, including requirements specifications, design, implementation, testing, and maintenance. Emphasis on software process, software tools (debuggers, profilers, source code repositories, test harnesses), software engineering techniques (time management, code, and documentation standards, source code management, object-oriented analysis and design), and team development practice. Much of the work will be in groups and will involve modifying preexisting software systems.",
                ProfessorUNID = "germain", ProfessorName = "H. James De St Germain", TimeDays = "TuTh 2:00PM - 3:20PM", Location = "WEB L104", Credits = 4, Enrolled = 150, Note = ""},
                // 3500
                new Course{Semester="Spring", Year=2022, Title="Software Practice", Department="CS", CourseNumber=3500, Section="001",
                    Description = "Practical exposure to the process of creating large software systems, including requirements specifications, design, implementation, testing, and maintenance. Emphasis on software process, software tools (debuggers, profilers, source code repositories, test harnesses), software engineering techniques (time management, code, and documentation standards, source code management, object-oriented analysis and design), and team development practice. Much of the work will be in groups and will involve modifying preexisting software systems.",
                ProfessorUNID = "germain", ProfessorName = "H. James De St Germain", TimeDays = "TuTh 2:00PM - 3:20PM", Location = "WEB L104", Credits = 4, Enrolled = 150, Note = ""},
                // 4150
                new Course{Semester="Spring", Year=2022, Title="Software Practice II", Department="CS", CourseNumber=4150, Section="001",
                    Description = "An in-depth study of traditional software development (using UML) from inception through implementation.  The entire class is team-based, and will include a project that uses an agile process.",
                ProfessorUNID = "dejohnso", ProfessorName = "David Johnson", TimeDays = "TuTh 12:25PM - 1:45PM", Location = "WEB L104", Credits = 3, Enrolled = 150, Note = ""},
                // 4400
                new Course{Semester="Spring", Year=2022, Title="Computer Systems", Department="CS", CourseNumber=4400, Section="001",
                    Description = "Introduction to computer systems from a programmer's point of view.  Machine level representations of programs, optimizing program performance, memory hierarchy, linking, exceptional control flow, measuring program performance, virtual memory, concurrent programming with threads, network programming.",
                ProfessorUNID = "benjones", ProfessorName = "Ben Jones", TimeDays = "MoWe 11:50AM - 1:10PM", Location = "HPR E 206", Credits = 3, Enrolled = 150, Note = "Need more TAs!"},
                // 4480
                new Course{Semester="Spring", Year=2022, Title="Computer Systems", Department="CS", CourseNumber=4480, Section="001",
                    Description = "Introduction to computer systems from a programmer's point of view.  Machine level representations of programs, optimizing program performance, memory hierarchy, linking, exceptional control flow, measuring program performance, virtual memory, concurrent programming with threads, network programming.",
                ProfessorUNID = "benjones", ProfessorName = "Ben Jones", TimeDays = "MoWe 11:50AM - 1:10PM", Location = "HPR E 206", Credits = 3, Enrolled = 150, Note = "Need more TAs!"},
                //4500
                new Course{Semester="Spring", Year=2022, Title="Computer Systems", Department="CS", CourseNumber=4500, Section="001",
                    Description = "Introduction to computer systems from a programmer's point of view.  Machine level representations of programs, optimizing program performance, memory hierarchy, linking, exceptional control flow, measuring program performance, virtual memory, concurrent programming with threads, network programming.",
                ProfessorUNID = "benjones", ProfessorName = "Ben Jones", TimeDays = "MoWe 11:50AM - 1:10PM", Location = "HPR E 206", Credits = 3, Enrolled = 150, Note = "Need more TAs!"},
                // 4530
                new Course{Semester="Spring", Year=2022, Title="Computer Systems", Department="CS", CourseNumber=4530, Section="001",
                    Description = "Introduction to computer systems from a programmer's point of view.  Machine level representations of programs, optimizing program performance, memory hierarchy, linking, exceptional control flow, measuring program performance, virtual memory, concurrent programming with threads, network programming.",
                ProfessorUNID = "benjones", ProfessorName = "Ben Jones", TimeDays = "MoWe 11:50AM - 1:10PM", Location = "HPR E 206", Credits = 3, Enrolled = 150, Note = "Need more TAs!"},
            };

            foreach (Course c in courses)
                db.Courses.Add(c);

            // Save the changes to the database.
            db.SaveChanges();

            if (db.EnrollmentOverTime.Any())
                return;

            using (var reader = new StreamReader("C:/Users/dtdet/Source/Repos/TAApplicaitonPS4/TAApplicationPS4/wwwroot/Uploads/temp.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();

                while (csv.Read())
                {
                    var cour = csv.GetField<string>("Course").Split(" ")[1];

                    foreach (Course c in courses)
                    {
                        if (c.CourseNumber == int.Parse(cour))
                        {
                            var enrollments = new EnrollmentOverTime[]
                            {
                                // Nov 1
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 1),
                                    Enrollment = csv.GetField<int>(" Nov 1")
                                },

                                // Nov 2
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 2),
                                    Enrollment = csv.GetField<int>(" Nov 2")
                                },

                                // Nov 3
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 3),
                                    Enrollment = csv.GetField<int>(" Nov 3")
                                },

                                // Nov 4
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 4),
                                    Enrollment = csv.GetField<int>(" Nov 4")
                                },

                                // Nov 5
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 5),
                                    Enrollment = csv.GetField<int>(" Nov 5")
                                },

                                // Nov 6
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 6),
                                    Enrollment = csv.GetField<int>(" Nov 6")
                                },

                                // Nov 7
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 7),
                                    Enrollment = csv.GetField<int>(" Nov 7")
                                },

                                // Nov 8
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 8),
                                    Enrollment = csv.GetField<int>(" Nov 8")
                                },

                                // Nov 9
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 9),
                                    Enrollment = csv.GetField<int>(" Nov 9")
                                },

                                // Nov 10
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 10),
                                    Enrollment = csv.GetField<int>(" Nov 10")
                                },

                                // Nov 11
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 11),
                                    Enrollment = csv.GetField<int>(" Nov 11")
                                },

                                // Nov 12
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 12),
                                    Enrollment = csv.GetField<int>(" Nov 12")
                                },

                                // Nov 13
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 13),
                                    Enrollment = csv.GetField<int>(" Nov 13")
                                },

                                // Nov 14
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 14),
                                    Enrollment = csv.GetField<int>(" Nov 14")
                                },

                                // Nov 15
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 15),
                                    Enrollment = csv.GetField<int>(" Nov 15")
                                },

                                // Nov 16
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 16),
                                    Enrollment = csv.GetField<int>(" Nov 16")
                                },

                                // Nov 17
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 17),
                                    Enrollment = csv.GetField<int>(" Nov 17")
                                },

                                // Nov 18
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 18),
                                    Enrollment = csv.GetField<int>(" Nov 18")
                                },

                                // Nov 19
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 19),
                                    Enrollment = csv.GetField<int>(" Nov 19")
                                },

                                // Nov 20
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 20),
                                    Enrollment = csv.GetField<int>(" Nov 20")
                                },

                                // Nov 21
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 21),
                                    Enrollment = csv.GetField<int>(" Nov 21")
                                },

                                // Nov 22
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 22),
                                    Enrollment = csv.GetField<int>(" Nov 22")
                                },

                                // Nov 23
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 23),
                                    Enrollment = csv.GetField<int>(" Nov 23")
                                },

                                // Nov 24
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 24),
                                    Enrollment = csv.GetField<int>(" Nov 24")
                                },

                                // Nov 25
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 25),
                                    Enrollment = csv.GetField<int>(" Nov 25")
                                },

                                // Nov 26
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 26),
                                    Enrollment = csv.GetField<int>(" Nov 26")
                                },

                                // Nov 27
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 27),
                                    Enrollment = csv.GetField<int>(" Nov 27")
                                },
                                
                                // Nov 28
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 28),
                                    Enrollment = csv.GetField<int>(" Nov 28")
                                },

                                // Nov 29
                                new EnrollmentOverTime
                                {
                                    CourseID = c.CourseID,
                                    EnrollmentDate = new DateTime(2021, 11, 29),
                                    Enrollment = csv.GetField<int>(" Nov 29")
                                },
                            };

                            foreach (EnrollmentOverTime e in enrollments)
                                db.EnrollmentOverTime.Add(e);

                            break;
                        }
                    }
                }
            }

            db.SaveChanges();

            Debug.WriteLine(db.EnrollmentOverTime.ToList()[0].Course.CourseNumber);
        }
    }
}
