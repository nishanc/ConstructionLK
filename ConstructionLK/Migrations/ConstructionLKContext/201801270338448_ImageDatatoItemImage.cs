namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageDatatoItemImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemImages", "ImageData", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemImages", "ImageData");
        }
    }
}
