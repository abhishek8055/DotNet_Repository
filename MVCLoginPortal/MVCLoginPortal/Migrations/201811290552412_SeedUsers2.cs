namespace MVCLoginPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'13e84323-c735-4292-9e27-abea70ef0bd7', N'test@gmail.com', 0, N'AEKQqr+oXc5SEeoq1CPAnqtK/m3r9JOSwU1ws+1cPW6F5NeuR14ZqNY49buALa0t5w==', N'8e05f006-5012-4d7f-9c1c-7e2991b809e6', NULL, 0, 0, NULL, 1, 0, N'test@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b97aeef6-9601-40da-933e-2a76f4f71738', N'admin@lucy.com', 0, N'AAncxptJ9yxI1n6MvI1E9SB0Iv/AUbfhZDbUXqpn9JyX5BQhLJ0uBgCY0k2iguZtNw==', N'e7828d78-9171-41e7-b9d3-7f572bebf3da', NULL, 0, 0, NULL, 1, 0, N'admin@lucy.com')
                   
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b9383bfe-6deb-49fe-b404-d98aee370648', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b97aeef6-9601-40da-933e-2a76f4f71738', N'b9383bfe-6deb-49fe-b404-d98aee370648')

");
        }
        
        public override void Down()
        {
        }
    }
}
