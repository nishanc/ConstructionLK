namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRequestIdfromLocation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locations", "RequestId", "dbo.ItemRequests");
            DropIndex("dbo.Locations", new[] { "RequestId" });
            DropColumn("dbo.Locations", "RequestId");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "RequestId", c => c.Int(nullable: false));
            CreateIndex("dbo.Locations", "RequestId");
            AddForeignKey("dbo.Locations", "RequestId", "dbo.ItemRequests", "Id");
        }
    }
}
