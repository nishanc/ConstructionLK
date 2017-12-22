namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemStatusTableAndKeys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Items", "StatusId", c => c.Int(nullable: true));
            CreateIndex("dbo.Items", "StatusId");
            AddForeignKey("dbo.Items", "StatusId", "dbo.ItemStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "StatusId", "dbo.ItemStatus");
            DropIndex("dbo.Items", new[] { "StatusId" });
            DropColumn("dbo.Items", "StatusId");
            DropTable("dbo.ItemStatus");
        }
    }
}
