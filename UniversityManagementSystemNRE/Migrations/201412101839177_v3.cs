namespace UniversityManagementSystemNRE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "AssignedTo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "AssignedTo", c => c.String());
        }
    }
}
