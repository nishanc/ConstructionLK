namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MetaDataTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MetaDatas",
                c => new
                    {
                        Data = c.String(nullable: false, maxLength: 250),
                        Value = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Data);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MetaDatas");
        }
    }
}
