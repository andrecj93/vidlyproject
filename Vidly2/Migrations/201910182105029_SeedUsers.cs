namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0736d483-2b12-4b3e-9361-2c0fe71aa8f5', N'guest@vidly.com', 0, N'AGxUDqAfvdNVjYTvLMwucVpP51AXpeOMlKi7uXK3NFvLaRYiMadjEJMhCZ7ADeVb9Q==', N'45466b1c-4ac2-4be7-8da1-6235d4ca6f3c', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5ec14881-e164-41cd-8080-212f8ae7b7d1', N'admin@vidly.com', 0, N'APbr14mrhjqziI3kD1xJK5IdMUoKPdqKEnBbUuUdxPTLmkJTyY1FhvkPRL+UO7IbeA==', N'864839ea-1d2d-4a75-9ae4-362e7a5f5f8d', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cb1b3149-5004-4cf9-8c16-ca5bb865723f', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5ec14881-e164-41cd-8080-212f8ae7b7d1', N'cb1b3149-5004-4cf9-8c16-ca5bb865723f')

");
        }
        
        public override void Down()
        {
        }
    }
}
