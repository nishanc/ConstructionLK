namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderStatusTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Action = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "Status", c => c.Int(nullable: true));
            CreateIndex("dbo.Orders", "Status");
            AddForeignKey("dbo.Orders", "Status", "dbo.OrderStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Status", "dbo.OrderStatus");
            DropIndex("dbo.Orders", new[] { "Status" });
            DropColumn("dbo.Orders", "Status");
            DropTable("dbo.OrderStatus");
        }
    }
}
