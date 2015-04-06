﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace UniversityManagementSystemNRE.Models
{
    public class Student
    {
        public int StudentID { set; get; }
        public string RegNo { set; get; }

        [Required(ErrorMessage = "Error : Student Name can not be empty !!!")]
        [Display(Name = "Student Name :- ")]
        public string StudentName { set; get; }

        public string Email { set; get; }
        public string ContactNo { set; get; }
        public DateTime AdmissionDate { set; get; }
        public string Address { set; get; }

        public virtual Department Department { set; get; }
        public int DepartmentID { set; get; }
    }
}
