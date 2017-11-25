namespace ConstructionLK.Migrations.ConstructionLKContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ServiceProviders", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.ServiceProviders", "MembershipTypeId");
            AddForeignKey("dbo.ServiceProviders", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceProviders", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.ServiceProviders", new[] { "MembershipTypeId" });
            DropColumn("dbo.ServiceProviders", "MembershipTypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
