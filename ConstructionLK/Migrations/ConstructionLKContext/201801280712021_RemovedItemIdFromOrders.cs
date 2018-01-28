namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedItemIdFromOrders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ItemId", "dbo.Items");
            DropIndex("dbo.Orders", new[] { "ItemId" });
            DropColumn("dbo.Orders", "ItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ItemId");
            AddForeignKey("dbo.Orders", "ItemId", "dbo.Items", "Id");
        }
    }
}
