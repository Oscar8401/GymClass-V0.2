namespace GymClass_v0._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GymClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        Description = c.String(),
                        GymClass_Id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GymClasses", t => t.GymClass_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.GymClass_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GymClasses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.GymClasses", "GymClass_Id", "dbo.GymClasses");
            DropIndex("dbo.GymClasses", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.GymClasses", new[] { "GymClass_Id" });
            DropTable("dbo.GymClasses");
        }
    }
}
