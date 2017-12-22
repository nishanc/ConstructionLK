namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusRemovedFromItems : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "StatusId", "dbo.Status");
            DropIndex("dbo.Items", new[] { "StatusId" });
            DropColumn("dbo.Items", "StatusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "StatusId");
            AddForeignKey("dbo.Items", "StatusId", "dbo.Status", "Id");
        }
    }
}
