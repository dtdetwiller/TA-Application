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
 *    This is the sender options class where we set the SendGridKey.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAApplicationPS4.Services
{
    public class AuthMessageSenderOptions
    {
        public string SendGridKey { get; set; }
    }
}
