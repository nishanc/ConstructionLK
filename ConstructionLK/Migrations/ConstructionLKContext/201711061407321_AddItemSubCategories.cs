namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemSubCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Commercial', 1)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Interior Deco', 2)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Furniture', 2)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Land Surveying', 3)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Housing Loans', 3)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Buildings', 4)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Industrial', 4)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Waterproofing', 5)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Landscaping', 5)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Flooring & Walls', 6)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Roofing', 6)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Electrical Installations', 7)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Power Systems', 7)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Data & Telephone', 8)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Cable TV', 8)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Piling', 9)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Mining', 9)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Laboratory', 10)");
            Sql("INSERT INTO ItemSubCategories (Name, MainCategoryId) VALUES ('Quality Control', 10)");
        }
        
        public override void Down()
        {
        }
    }
}
