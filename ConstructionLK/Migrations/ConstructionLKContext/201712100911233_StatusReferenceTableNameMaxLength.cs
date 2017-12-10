namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusReferenceTableNameMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Status", "Name", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Status", "Name", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
