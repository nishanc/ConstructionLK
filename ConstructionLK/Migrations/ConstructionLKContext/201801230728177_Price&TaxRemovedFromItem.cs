namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceTaxRemovedFromItem : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "Price");
            DropColumn("dbo.Items", "Tax");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Tax", c => c.Single());
            AddColumn("dbo.Items", "Price", c => c.Single(nullable: false));
        }
    }
}
