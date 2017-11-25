namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerRemovedPW : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Password", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
