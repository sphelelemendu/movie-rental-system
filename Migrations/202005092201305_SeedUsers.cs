namespace MovieApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7ff36915-1f29-4aca-a09e-fa0d5b42e313', N'admin@movies.com', 0, N'ADk2zlK57IzCIJ4dPtfGj7pDu6JqSB58WWsXM+LGM86mBN8xfOuyYAH1QeofPKDFJA==', N'c0197fbb-7ebf-40cc-8b77-922aa6b4fe7d', NULL, 0, 0, NULL, 1, 0, N'admin@movies.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f451c29c-9ff3-40e7-8c00-99cbbb2fe880', N'guest@movies.com', 0, N'AC9+BjpaqZ1FXv45DFSk4ny2v+rT4judoDaUxwAZzRIhc38cUs/OB3+h/LFLs+SkKw==', N'de29446d-d68f-4494-9fa6-fa4bcbc73983', NULL, 0, 0, NULL, 1, 0, N'guest@movies.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'631e3bfb-fc27-4de6-8499-64a59f453e7e', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7ff36915-1f29-4aca-a09e-fa0d5b42e313', N'631e3bfb-fc27-4de6-8499-64a59f453e7e')

");
        }
        
        public override void Down()
        {
        }
    }
}
