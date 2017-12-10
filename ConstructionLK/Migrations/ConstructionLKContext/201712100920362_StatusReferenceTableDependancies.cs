namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusReferenceTableDependancies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "StatusId", c => c.Int(nullable: true));
            AddColumn("dbo.ServiceProviders", "StatusId", c => c.Int(nullable: true));
            AddColumn("dbo.Items", "StatusId", c => c.Int(nullable: true));
            CreateIndex("dbo.Customers", "StatusId");
            CreateIndex("dbo.ServiceProviders", "StatusId");
            CreateIndex("dbo.Items", "StatusId");
            AddForeignKey("dbo.Customers", "StatusId", "dbo.Status", "Id");
            AddForeignKey("dbo.Items", "StatusId", "dbo.Status", "Id");
            AddForeignKey("dbo.ServiceProviders", "StatusId", "dbo.Status", "Id");
            DropColumn("dbo.Customers", "Status");
            DropColumn("dbo.ServiceProviders", "Status");
            DropColumn("dbo.Items", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Status", c => c.Int());
            AddColumn("dbo.ServiceProviders", "Status", c => c.Int());
            AddColumn("dbo.Customers", "Status", c => c.Int());
            DropForeignKey("dbo.ServiceProviders", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Items", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Customers", "StatusId", "dbo.Status");
            DropIndex("dbo.Items", new[] { "StatusId" });
            DropIndex("dbo.ServiceProviders", new[] { "StatusId" });
            DropIndex("dbo.Customers", new[] { "StatusId" });
            DropColumn("dbo.Items", "StatusId");
            DropColumn("dbo.ServiceProviders", "StatusId");
            DropColumn("dbo.Customers", "StatusId");
        }
    }
}
