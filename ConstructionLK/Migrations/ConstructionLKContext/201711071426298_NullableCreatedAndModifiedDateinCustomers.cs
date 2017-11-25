namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableCreatedAndModifiedDateinCustomers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
