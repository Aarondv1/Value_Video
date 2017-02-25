namespace Value_Video.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e3f1af7a-3bb4-4587-ac6a-e7bb9eef1a3f', N'Admin@accounts.com', 0, N'ALY5kTvBXqZFId/0hVgA/0eqKWrJwESxl89rWVozJ7QC5xD+UzMQzgt1Xjduv08LTA==', N'f56d4f05-2be3-4c85-bc98-219b1c138f75', NULL, 0, 0, NULL, 1, 0, N'Admin@accounts.com')");
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'eee0372f-62ec-49d8-b592-c4117b681f92', N'Guest@accounts.com', 0, N'ABmkTwg9nhQWn0F77KFiQyF090usEPv5k9oQ3Q1EA32szkx/R+3+H2GS//be19yuyw==', N'62935ff4-a434-426f-ad9c-13e1f30b28aa', NULL, 0, 0, NULL, 1, 0, N'Guest@accounts.com')");
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'93b2c3cf-6200-4a2c-93fb-32a8f84731be', N'CanManageMovies')");
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e3f1af7a-3bb4-4587-ac6a-e7bb9eef1a3f', N'93b2c3cf-6200-4a2c-93fb-32a8f84731be')");
        }
        
        public override void Down()
        {
        }
    }
}
