/**
 * Author:    Daniel Detwiller
 * Partner:   None
 * Date:      12-10-2021
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
 *    This is the enrollment over time model, its holds all the fields for the database of an enrollment.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAApplicationPS4.Models
{
    public class EnrollmentOverTime
    {

        // The ID of this model
        public int EnrollmentOverTimeID { get; set; }
        // The ID of the course
        public int CourseID { get; set; }
        // The course
        public Course Course { get; set; }
        // Date the enrollment was taken
        public DateTime EnrollmentDate { get; set; }
        // The enrollment number
        public int Enrollment { get; set; }

    }
}
