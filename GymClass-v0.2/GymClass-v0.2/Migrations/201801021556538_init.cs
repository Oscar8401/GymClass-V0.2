namespace GymClass_v0._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GymClasses", "ClassType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GymClasses", "ClassType");
        }
    }
}
