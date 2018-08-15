namespace VidlyUA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers2 : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3b2904ee-4979-44cb-ae09-c5e1d7d74051', N'admin@vidly.com', 0, N'AG22jmv7/317OOz7M9DyPbjOMUSiLWHjS986j8A25ZEb9SojodsYbqAOfUExwM1Clw==', N'1ec9c10e-2ac8-475f-aab5-d619fda5666a', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'483b76a4-b7c7-4d73-a9b9-9406e3783a64', N'stp.parsons@gmail.com', 0, N'AHk/+EMggHw+G6CEM2SvypFH63O9g9FPLCiRz4n2Ld9qTsdUqhPzn/Y79wBISZJRJQ==', N'9e549542-0213-4522-aa02-970b51761092', NULL, 0, 0, NULL, 1, 0, N'stp.parsons@gmail.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e5b4f43e-ce5d-48ca-a6f6-a111669d0df4', N'guest@vidly.com', 0, N'AP/uFnvJ8QWMD663xD6NpcYiIqXKGxnqMBZgZXQlzC5MyMdn/bPj9sT80jznN5Le6A==', N'e45fb966-7350-4fc0-a9aa-3a52ba1d7600', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a02c50c8-ff11-4fa1-b4da-20d796875711', N'CanManageMovies')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3b2904ee-4979-44cb-ae09-c5e1d7d74051', N'a02c50c8-ff11-4fa1-b4da-20d796875711')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
