namespace UniversityManagementSystemNRE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AllocatedRooms", "StartTime");
            DropColumn("dbo.AllocatedRooms", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AllocatedRooms", "EndTime", c => c.String(nullable: false));
            AddColumn("dbo.AllocatedRooms", "StartTime", c => c.String(nullable: false));
        }
    }
}
