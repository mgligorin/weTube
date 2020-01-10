namespace WeTube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Description = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        Role = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        IsBlocked = c.Boolean(nullable: false),
                        AppUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.LikeRatios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsLiked = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        VideoId = c.Int(),
                        CommentId = c.Int(),
                        AppUser_Id = c.Int(),
                        AppUser_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.CommentId)
                .ForeignKey("dbo.Videos", t => t.VideoId)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_Id1)
                .Index(t => t.VideoId)
                .Index(t => t.CommentId)
                .Index(t => t.AppUser_Id)
                .Index(t => t.AppUser_Id1);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        VideoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.VideoId);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Thumbnail = c.String(),
                        Description = c.String(),
                        Visibility = c.Int(nullable: false),
                        CommentAvailability = c.Boolean(nullable: false),
                        RatioAvailability = c.Boolean(nullable: false),
                        IsBlocked = c.Boolean(nullable: false),
                        Views = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.LikeRatios", "AppUser_Id1", "dbo.AppUsers");
            DropForeignKey("dbo.AppUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppUsers", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.LikeRatios", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.LikeRatios", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.LikeRatios", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.Videos", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AppUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Videos", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "VideoId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.LikeRatios", new[] { "AppUser_Id1" });
            DropIndex("dbo.LikeRatios", new[] { "AppUser_Id" });
            DropIndex("dbo.LikeRatios", new[] { "CommentId" });
            DropIndex("dbo.LikeRatios", new[] { "VideoId" });
            DropIndex("dbo.AppUsers", new[] { "AppUser_Id" });
            DropIndex("dbo.AppUsers", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Videos");
            DropTable("dbo.Comments");
            DropTable("dbo.LikeRatios");
            DropTable("dbo.AppUsers");
        }
    }
}
