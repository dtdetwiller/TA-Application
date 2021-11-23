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
 *    This is the user time slots model, its holds all the fields for the database of a users time slots.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAApplicationPS4.Models
{
    public class TimeSlots
    {
        public int TimeSlotsID { get; set; }
        // Tie to the users ID
        public string UserID { get; set; }
        // Monday time slots
        public string Monday { get; set; }
        // Tuesday time slots
        public string Tuesday { get; set; }
        // Wednesday time slots
        public string Wednesday { get; set; }
        // Thursday time slots
        public string Thursday { get; set; }
        // Friday time slots
        public string Friday { get; set; }

        public TimeSlots()
        {
            // 48 15 minutes slots, Y means active N means not active.
            // Initialize all the arrays
            Monday = "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN";
            Tuesday = "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN";
            Wednesday = "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN";
            Thursday = "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN";
            Friday = "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN";
        }
    }
}
