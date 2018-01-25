namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrdersTable : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.ItemProperties");
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Price = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ItemId)
                .Index(t => t.UserId);
            
            //AlterColumn("dbo.ItemProperties", "Id", c => c.Int(nullable: false, identity: true));
            //AddPrimaryKey("dbo.ItemProperties", new[] { "Id", "ItemId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "ItemId", "dbo.Items");
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "ItemId" });
            //DropPrimaryKey("dbo.ItemProperties");
            //AlterColumn("dbo.ItemProperties", "Id", c => c.Int(nullable: false));
            DropTable("dbo.Orders");
            //AddPrimaryKey("dbo.ItemProperties", new[] { "Id", "ItemId" });
        }
    }
}
