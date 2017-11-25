namespace ConstructionLK.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReSeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'66c49509-bc92-4623-898d-e84e903be16f', N'admin@constructionlk.com', 0, N'AOjSNcwyW4Qg2z281gqLy8ztM5HgD6XCzXOnGS/NJnuVHdNAjGreyD/v2tv68FQ7HQ==', N'a7509f8c-bae7-4d9a-a003-75e4e786d472', NULL, 0, 0, NULL, 1, 0, N'admin@constructionlk.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'806c1876-0fed-47da-8ebd-520cd1678e8a', N'guest@constructionlk.com', 0, N'ADvkHgGVTUDALMEnaSwK+oZrjEG0uAy69dcvKOoUXEurYJ7eyZACuB6kSGfKMdJF+A==', N'3855db69-4f4b-410d-aa45-6a8cc2f13a7c', NULL, 0, 0, NULL, 1, 0, N'guest@constructionlk.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'30d86609-5482-494d-9a99-624691a4b7f3', N'CanManageAll')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'66c49509-bc92-4623-898d-e84e903be16f', N'30d86609-5482-494d-9a99-624691a4b7f3')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
