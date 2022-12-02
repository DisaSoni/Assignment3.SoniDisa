using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment3.SoniDisa.Models
{
    public class Teacher
    {
        //the following properties/fields define an teacher

        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public DateTime TeacherHireDate;
        public decimal TeacherSalary;
        
        public string EmployeeNumber { get; internal set; }
    }
}