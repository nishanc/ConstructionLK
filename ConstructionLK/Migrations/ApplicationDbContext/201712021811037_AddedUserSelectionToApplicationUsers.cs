namespace ConstructionLK.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserSelectionToApplicationUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserSelection", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserSelection");
        }
    }
}
