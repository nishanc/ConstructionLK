namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerCurrentLocation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerCurrentLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerCurrentLocations", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerCurrentLocations", new[] { "CustomerId" });
            DropTable("dbo.CustomerCurrentLocations");
        }
    }
}
