namespace GymClass_v0._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GymClasses", "GymClass_Id", "dbo.GymClasses");
            DropForeignKey("dbo.GymClasses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.GymClasses", new[] { "GymClass_Id" });
            DropIndex("dbo.GymClasses", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.ApplicationUserGymClasses",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        GymClass_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.GymClass_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.GymClasses", t => t.GymClass_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.GymClass_Id);
            
            DropColumn("dbo.GymClasses", "GymClass_Id");
            DropColumn("dbo.GymClasses", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GymClasses", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.GymClasses", "GymClass_Id", c => c.Int());
            DropForeignKey("dbo.ApplicationUserGymClasses", "GymClass_Id", "dbo.GymClasses");
            DropForeignKey("dbo.ApplicationUserGymClasses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserGymClasses", new[] { "GymClass_Id" });
            DropIndex("dbo.ApplicationUserGymClasses", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserGymClasses");
            CreateIndex("dbo.GymClasses", "ApplicationUser_Id");
            CreateIndex("dbo.GymClasses", "GymClass_Id");
            AddForeignKey("dbo.GymClasses", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.GymClasses", "GymClass_Id", "dbo.GymClasses", "Id");
        }
    }
}
