namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemPriceAndTax : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Price", c => c.Single(nullable: false));
            AddColumn("dbo.Items", "Tax", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Tax");
            DropColumn("dbo.Items", "Price");
        }
    }
}
