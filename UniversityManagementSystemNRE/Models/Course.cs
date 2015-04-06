﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using UniversityManagementSystemNRE.Models;

namespace UniversityManagementSystemNRE.Models
{
    public class Course
    {
        public int CourseID { set; get; }

        [Required(ErrorMessage = "Course Code can not be empty!")]
        [Remote("Check_CourseCode", "Courses", ErrorMessage = "Course code already exists!")]
        [Display(Name = "Course Code")]
        public string CourseCode { set; get; }

        [Required(ErrorMessage = "Course Name can not be empty!")]
        [Remote("Check_CourseName", "Courses", ErrorMessage = "Course name already exists!")]
        [Display(Name = "Name")]
        public string CourseName { set; get; }

        public double Credit { set; get; }
        public string Description { set; get; }

        public virtual Department Department { set; get; }
        public int DepartmentID { set; get; }

        public virtual Semester Semester { set; get; }
        public int SemesterID { set; get; }

        public virtual List<AllocatedRoom> AllocatedRoomList { set; get; }

        //public string AssignedTo { set; get; }
    }
}
