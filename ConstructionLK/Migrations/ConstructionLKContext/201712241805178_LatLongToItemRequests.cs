namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LatLongToItemRequests : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemRequests", "Latitude", c => c.Single());
            AddColumn("dbo.ItemRequests", "Longitude", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemRequests", "Longitude");
            DropColumn("dbo.ItemRequests", "Latitude");
        }
    }
}
