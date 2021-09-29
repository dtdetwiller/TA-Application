using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAApplicationPS4.Models
{
    public class Application
    {
        // Name of applicant
        // University ID of the Applicant
        public int ID { get; set; }
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

    }
}
