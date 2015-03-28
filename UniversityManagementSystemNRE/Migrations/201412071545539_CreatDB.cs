namespace UniversityManagementSystemNRE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllocatedRooms",
                c => new
                    {
                        AllocatedRoomID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        RoomID = c.Int(nullable: false),
                        WeekDayID = c.Int(nullable: false),
                        StartTime = c.String(nullable: false),
                        EndTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AllocatedRoomID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .ForeignKey("dbo.WeekDays", t => t.WeekDayID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.RoomID)
                .Index(t => t.WeekDayID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(nullable: false),
                        CourseName = c.String(nullable: false),
                        Credit = c.Double(nullable: false),
                        Description = c.String(),
                        DepartmentID = c.Int(nullable: false),
                        SemesterID = c.Int(nullable: false),
                        AssignedTo = c.String(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterID, cascadeDelete: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.SemesterID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DeptCode = c.String(nullable: false),
                        DeptName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        RegNo = c.String(),
                        StudentName = c.String(nullable: false),
                        Email = c.String(),
                        ContactNo = c.String(),
                        AdmissionDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        DepartmentID = c.Int(nullable: false),
                        Department_DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentID)
                .Index(t => t.DepartmentID)
                .Index(t => t.Department_DepartmentID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false),
                        Address = c.String(),
                        Email = c.String(nullable: false),
                        ContactNo = c.String(),
                        CreditsToBeTaken = c.Double(nullable: false),
                        CreditsHaveTaken = c.Double(nullable: false),
                        CreditsRemaining = c.Double(nullable: false),
                        DesignationID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        Designation_DesignationID = c.Int(),
                        Department_DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.TeacherID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID)
                .ForeignKey("dbo.Designations", t => t.Designation_DesignationID)
                .ForeignKey("dbo.Designations", t => t.DesignationID)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentID)
                .Index(t => t.DepartmentID)
                .Index(t => t.Designation_DesignationID)
                .Index(t => t.DesignationID)
                .Index(t => t.Department_DepartmentID);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationID = c.Int(nullable: false, identity: true),
                        DsgName = c.String(),
                    })
                .PrimaryKey(t => t.DesignationID);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemesterID = c.Int(nullable: false, identity: true),
                        SemesterName = c.String(),
                    })
                .PrimaryKey(t => t.SemesterID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        RoomNo = c.String(),
                    })
                .PrimaryKey(t => t.RoomID);
            
            CreateTable(
                "dbo.WeekDays",
                c => new
                    {
                        WeekDayID = c.Int(nullable: false, identity: true),
                        DayName = c.String(),
                    })
                .PrimaryKey(t => t.WeekDayID);
            
            CreateTable(
                "dbo.AssignedCourses",
                c => new
                    {
                        AssignedCourseID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignedCourseID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                        GradeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Grades", t => t.GradeID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.GradeID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeID = c.Int(nullable: false, identity: true),
                        GradeLetter = c.String(),
                    })
                .PrimaryKey(t => t.GradeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.Enrollments", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.AssignedCourses", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.AssignedCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.AllocatedRooms", "WeekDayID", "dbo.WeekDays");
            DropForeignKey("dbo.AllocatedRooms", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Courses", "SemesterID", "dbo.Semesters");
            DropForeignKey("dbo.Teachers", "Department_DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Teachers", "DesignationID", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "Designation_DesignationID", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Students", "Department_DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Students", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Courses", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.AllocatedRooms", "CourseID", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "StudentID" });
            DropIndex("dbo.Enrollments", new[] { "GradeID" });
            DropIndex("dbo.Enrollments", new[] { "CourseID" });
            DropIndex("dbo.AssignedCourses", new[] { "TeacherID" });
            DropIndex("dbo.AssignedCourses", new[] { "CourseID" });
            DropIndex("dbo.AllocatedRooms", new[] { "WeekDayID" });
            DropIndex("dbo.AllocatedRooms", new[] { "RoomID" });
            DropIndex("dbo.Courses", new[] { "SemesterID" });
            DropIndex("dbo.Teachers", new[] { "Department_DepartmentID" });
            DropIndex("dbo.Teachers", new[] { "DesignationID" });
            DropIndex("dbo.Teachers", new[] { "Designation_DesignationID" });
            DropIndex("dbo.Teachers", new[] { "DepartmentID" });
            DropIndex("dbo.Students", new[] { "Department_DepartmentID" });
            DropIndex("dbo.Students", new[] { "DepartmentID" });
            DropIndex("dbo.Courses", new[] { "DepartmentID" });
            DropIndex("dbo.AllocatedRooms", new[] { "CourseID" });
            DropTable("dbo.Grades");
            DropTable("dbo.Enrollments");
            DropTable("dbo.AssignedCourses");
            DropTable("dbo.WeekDays");
            DropTable("dbo.Rooms");
            DropTable("dbo.Semesters");
            DropTable("dbo.Designations");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
            DropTable("dbo.AllocatedRooms");
        }
    }
}
