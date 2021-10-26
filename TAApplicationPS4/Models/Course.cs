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
 *    This is the course model, its holds all the fields for the database of a course.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAApplicationPS4.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        // The semester that the course is offered in.
        public string Semester { get; set; }
        // Year course is offered
        public int Year { get; set; }
        // Title of the course
        public string Title { get; set; }
        // Department the course is in (CS, CE, ME)
        public string Department { get; set; }
        // Course Number
        public int CourseNumber { get; set; }
        // Section
        public string Section { get; set; }
        // Decription of the course
        public string Description { get; set; }
        // The professors UNID
        public string ProfessorUNID { get; set; }
        // The professors name
        public string ProfessorName { get; set; }
        // Time and days the course is offered
        public string TimeDays { get; set; }
        // The location of the course
        public string Location { get; set; }
        // Amount of credit hours
        public int Credits { get; set; }
        // The amount of students enrolled
        public int Enrolled { get; set; }
        // Note for professors to leave about the class
        public string Note { get; set; }
    }
}
