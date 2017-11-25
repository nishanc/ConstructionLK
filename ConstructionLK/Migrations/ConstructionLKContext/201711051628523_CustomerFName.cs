namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerFName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
