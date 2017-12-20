namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplainBodyToComplains : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Complains", "ComplainBody", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Complains", "ComplainBody");
        }
    }
}
