namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminCreatedDateModifiedDateNotNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AdministrativeStaff", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AdministrativeStaff", "ModifiedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AdministrativeStaff", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.AdministrativeStaff", "CreatedDate", c => c.DateTime());
        }
    }
}
