namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAvatarTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAvatars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                        Type = c.String(),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceProviders", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAvatars", "UserId", "dbo.ServiceProviders");
            DropIndex("dbo.UserAvatars", new[] { "UserId" });
            DropTable("dbo.UserAvatars");
        }
    }
}
