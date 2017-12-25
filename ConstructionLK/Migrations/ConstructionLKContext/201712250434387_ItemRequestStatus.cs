namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemRequestStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemRequestStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ItemRequests", "StatusId", c => c.Int(nullable: true));
            CreateIndex("dbo.ItemRequests", "StatusId");
            AddForeignKey("dbo.ItemRequests", "StatusId", "dbo.ItemRequestStatus", "Id");
            DropColumn("dbo.ItemRequests", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemRequests", "Status", c => c.Int(nullable: false));
            DropForeignKey("dbo.ItemRequests", "StatusId", "dbo.ItemRequestStatus");
            DropIndex("dbo.ItemRequests", new[] { "StatusId" });
            DropColumn("dbo.ItemRequests", "StatusId");
            DropTable("dbo.ItemRequestStatus");
        }
    }
}
