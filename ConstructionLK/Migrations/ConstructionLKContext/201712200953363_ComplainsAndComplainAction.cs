namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplainsAndComplainAction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Complains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComplainedDate = c.DateTime(nullable: false),
                        ActionId = c.Int(nullable: false),
                        ComplainedBy = c.String(nullable: false, maxLength: 128),
                        ComplainedAbout = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComplainActions", t => t.ActionId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.ComplainedAbout, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.ComplainedBy, cascadeDelete: false)
                .Index(t => t.ActionId)
                .Index(t => t.ComplainedAbout)
                .Index(t => t.ComplainedBy);

            CreateTable(
                "dbo.ComplainActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Action = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Complains", "ComplainedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Complains", "ComplainedAbout", "dbo.AspNetUsers");
            DropForeignKey("dbo.Complains", "ActionId", "dbo.ComplainActions");
            DropIndex("dbo.Complains", new[] { "ComplainedAbout" });
            DropIndex("dbo.Complains", new[] { "ComplainedBy" });
            DropIndex("dbo.Complains", new[] { "ActionId" });
            DropTable("dbo.ComplainActions");
            DropTable("dbo.Complains");
        }
    }
}
