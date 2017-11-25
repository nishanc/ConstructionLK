namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemMainCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ItemMainCategories (Name,  Description) VALUES ('General Constructions','Meet abundant service providers in diverse specializations in order to meet your building project task successfully')");
            Sql("INSERT INTO ItemMainCategories (Name,  Description) VALUES ('Academic and Professional','Meet abundant service providers in diverse specializations in order to meet your building project task successfully')");
            Sql("INSERT INTO ItemMainCategories (Name,  Description) VALUES ('Major Constructions','Meet abundant service providers in diverse specializations in order to meet your building project task successfully')");
            Sql("INSERT INTO ItemMainCategories (Name,  Description) VALUES ('Specialized Services','Meet abundant service providers in diverse specializations in order to meet your building project task successfully')");
            Sql("INSERT INTO ItemMainCategories (Name,  Description) VALUES ('Fabrications, Installations & Wood works','Meet abundant service providers in diverse specializations in order to meet your building project task successfully')");
            Sql("INSERT INTO ItemMainCategories (Name, Description) VALUES ('Mechanical, Electrical and Plumbing','Meet abundant service providers in diverse specializations in order to meet your building project task successfully')");
            Sql("INSERT INTO ItemMainCategories (Name,  Description) VALUES ('Low Voltage systems','Meet abundant service providers in diverse specializations in order to meet your building project task successfully')");
            Sql("INSERT INTO ItemMainCategories (Name,  Description) VALUES ('Geo-technical','Meet abundant service providers in diverse specializations in order to meet your building project task successfully')");
            Sql("INSERT INTO ItemMainCategories (Name,  Description) VALUES ('Quality and Testing','Meet abundant service providers in diverse specializations in order to meet your building project task successfully')");
        }
        
        public override void Down()
        {
        }
    }
}
