namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceProviderRemovedPW : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ServiceProviders", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceProviders", "Password", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
