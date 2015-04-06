﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//   Extreme Team
//   BASIS   
using UniversityManagementSystemNRE.Models;

namespace UniversityManagementSystemNRE.Models
{
    public class UniMenSysDbContext : DbContext
    {
        public DbSet<Department> DepartmentDbSet { set; get; }
        public DbSet<Semester> SemesterDbSet { set; get; }
        public DbSet<Course> CourseDbSet { set; get; }
        public DbSet<Designation> DesignationDbSet { set; get; }
        public DbSet<Teacher> TeacherDbSet { set; get; }
        public DbSet<AssignedCourse> AssignedCourseDbSet { get; set; }
        public DbSet<Student> StudentDbSet { set; get; }
        public DbSet<Grade> GradeDbSet { set; get; }
        public DbSet<Enrollment> EnrollmentDbSet { set; get; }
        public DbSet<WeekDay> WeekDayDbSet { set; get; }
        public DbSet<Room> RoomDbSet { set; get; }
        public DbSet<AllocatedRoom> AllocatedRoomDbSet { set; get; }

        public UniMenSysDbContext()
            : base("name=UniMenSysDbContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasRequired(t => t.Department).WithMany().HasForeignKey(t => t.DepartmentID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Teacher>().HasRequired(t => t.Designation).WithMany().HasForeignKey(t => t.DesignationID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Student>().HasRequired(s =>s.Department).WithMany().HasForeignKey(s =>s.DepartmentID).WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}