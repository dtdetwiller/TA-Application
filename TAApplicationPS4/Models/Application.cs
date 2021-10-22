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
 *    This is the application model, its holds all the fields for the database of an applicant.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAApplicationPS4.Models
{
    public class Application
    {
        public int ID { get; set; }
        // University ID of the Applicant
        public string uID { get; set; }
        // Name of applicant
        public string Name { get; set; }
        // Phone number
        public string Phone { get; set; }
        // Email Address
        public string Email { get; set; }
        // Current Degree the applicant is pursuing
        public string Degree { get; set; }
        // Current program the applicant is pursuing
        public string Program { get; set; }
        // U of U GPA
        public float GPA { get; set; }
        // Number of hours the applicant wants to work
        public int Hours { get; set; }
        // Personal statement
        public string PersonalStatement { get; set; }
        // English fluency
        public enum Fluency { Native, Fluent, Adequate, Poor, None }
        // Semesters completed at the U
        public int Semesters { get; set; }
        // LinkedIn URL
        public string LinkedInURL { get; set; }
        // Resume file upload
        public string Resume { get; set; }
        // Application creation date
        public DateTime CreationDate { get; set; }
        // Application modification date
        public DateTime? ModificationDate { get; set; }
        // User ID
        public string UserID { get; set; }

    }
}
