namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedQuantityFromOrders : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Quantity", c => c.Int(nullable: false));
        }
    }
}
