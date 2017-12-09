namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminStaffRemovedPasswordEmail : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AdministrativeStaff", "Password");
            DropColumn("dbo.AdministrativeStaff", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdministrativeStaff", "Email", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AdministrativeStaff", "Password", c => c.String(nullable: false));
        }
    }
}
