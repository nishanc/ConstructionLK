namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedItemLocationsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemLocations", "ItemId", "dbo.Items");
            DropIndex("dbo.ItemLocations", new[] { "ItemId" });
            DropTable("dbo.ItemLocations");
        }
    }
}
