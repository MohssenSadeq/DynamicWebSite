namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class social : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cardinfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        title = c.String(nullable: false, maxLength: 59),
                        describtion = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                        pic = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        classname = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Carsuals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        describtion = c.String(nullable: false),
                        contenet = c.String(),
                        alt = c.String(),
                        date = c.DateTime(nullable: false),
                        pic = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.centers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        classname = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.colleges",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        centerID = c.Int(nullable: false),
                        name = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                        photo = c.String(),
                        about = c.String(nullable: false),
                        userid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.centers", t => t.centerID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userid)
                .Index(t => t.centerID)
                .Index(t => t.userid);
            
            CreateTable(
                "dbo.departments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        photo = c.String(),
                        about = c.String(nullable: false),
                        collegeid = c.Int(nullable: false),
                        userid = c.String(maxLength: 128),
                        dgreeid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.colleges", t => t.collegeid, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userid)
                .Index(t => t.collegeid)
                .Index(t => t.userid);
            
            CreateTable(
                "dbo.Theses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        departmentID = c.Int(nullable: false),
                        name = c.String(nullable: false),
                        title = c.String(nullable: false),
                        supervisor = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                        thesistype = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.departments", t => t.departmentID, cascadeDelete: true)
                .Index(t => t.departmentID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserType = c.String(),
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
                "dbo.staffs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        name_en = c.String(),
                        date = c.DateTime(nullable: false),
                        photo = c.String(),
                        about = c.String(),
                        collegesid = c.Int(nullable: false),
                        userid = c.String(maxLength: 128),
                        user_name = c.String(),
                        password = c.String(),
                        dgreesid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.colleges", t => t.collegesid, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userid)
                .Index(t => t.collegesid)
                .Index(t => t.userid);
            
            CreateTable(
                "dbo.Request_to_edit",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        dgreeid = c.Int(nullable: false),
                        staffid = c.Int(nullable: false),
                        fullName = c.String(nullable: false, maxLength: 59),
                        Email = c.String(nullable: false),
                        phoneNum = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                        pic = c.String(),
                        picuni = c.String(),
                        states = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.staffs", t => t.staffid, cascadeDelete: true)
                .Index(t => t.staffid);
            
            CreateTable(
                "dbo.footers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        mainfoot = c.Int(nullable: false),
                        title = c.String(nullable: false, maxLength: 59),
                        describtion = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                        pic = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.socials",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        social_name = c.Int(nullable: false),
                        link = c.String(nullable: false),
                        icon = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.social_name, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.colleges", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.staffs", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.Request_to_edit", "staffid", "dbo.staffs");
            DropForeignKey("dbo.staffs", "collegesid", "dbo.colleges");
            DropForeignKey("dbo.departments", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Theses", "departmentID", "dbo.departments");
            DropForeignKey("dbo.departments", "collegeid", "dbo.colleges");
            DropForeignKey("dbo.colleges", "centerID", "dbo.centers");
            DropForeignKey("dbo.cardinfoes", "CategoryID", "dbo.Categories");
            DropIndex("dbo.socials", new[] { "social_name" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Request_to_edit", new[] { "staffid" });
            DropIndex("dbo.staffs", new[] { "userid" });
            DropIndex("dbo.staffs", new[] { "collegesid" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Theses", new[] { "departmentID" });
            DropIndex("dbo.departments", new[] { "userid" });
            DropIndex("dbo.departments", new[] { "collegeid" });
            DropIndex("dbo.colleges", new[] { "userid" });
            DropIndex("dbo.colleges", new[] { "centerID" });
            DropIndex("dbo.cardinfoes", new[] { "CategoryID" });
            DropTable("dbo.socials");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.footers");
            DropTable("dbo.Request_to_edit");
            DropTable("dbo.staffs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Theses");
            DropTable("dbo.departments");
            DropTable("dbo.colleges");
            DropTable("dbo.centers");
            DropTable("dbo.Carsuals");
            DropTable("dbo.Categories");
            DropTable("dbo.cardinfoes");
        }
    }
}
