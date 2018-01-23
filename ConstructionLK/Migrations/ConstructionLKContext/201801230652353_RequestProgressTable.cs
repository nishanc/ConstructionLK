namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestProgressTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequestProgresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReqId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        value = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemRequests", t => t.ReqId)
                .Index(t => t.ReqId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestProgresses", "ReqId", "dbo.ItemRequests");
            DropIndex("dbo.RequestProgresses", new[] { "ReqId" });
            DropTable("dbo.RequestProgresses");
        }
    }
}
