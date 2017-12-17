namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDateTimeAdminStaff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AdministrativeStaff", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.AdministrativeStaff", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AdministrativeStaff", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AdministrativeStaff", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
