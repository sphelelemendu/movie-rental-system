namespace MovieApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsersCanManageMovies : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense]) VALUES (N'7300df0d-459f-4d25-aa63-7899f29c3f09', N'visitor@sphelelemendu.com', 0, N'AESKWAUD7Q4nWpO2rt7VXZPcbxBTbgYe8tX7GaOkQwr3yC6AjQ+Eg1LrUesf/volgQ==', N'effff5e9-b423-4bcc-8e12-357536347546', NULL, 0, 0, NULL, 1, 0, N'visitor@sphelelemendu.com', N'visitor@sphelelemendu.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense]) VALUES (N'aa53e240-f923-4edc-a1c9-fde5b19182d6', N'admin@sphelelemendu.com', 0, N'AAxD7nvU16ZNsUzFC+1S42NPjaYqXK2RKOoZRoZg6IfLiAhg1/nDwsymS3X1e/EVlg==', N'2fe4ce72-1aef-4da3-a12e-f36dfbb98247', NULL, 0, 0, NULL, 1, 0, N'admin@sphelelemendu.com', N'admin@sphelelemendu.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5ddb6366-54b6-4c8e-8092-c9b4f81c2582', N'CanManageMoviesUpdated')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'aa53e240-f923-4edc-a1c9-fde5b19182d6', N'5ddb6366-54b6-4c8e-8092-c9b4f81c2582')

");
        }
        
        public override void Down()
        {
        }
    }
}
