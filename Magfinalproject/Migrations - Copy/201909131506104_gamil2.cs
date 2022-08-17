namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gamil2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.asks", "userid", c => c.String(maxLength: 128));
            AddColumn("dbo.cardinfoes", "userid", c => c.String(maxLength: 128));
            AddColumn("dbo.Categories", "userid", c => c.String(maxLength: 128));
            AddColumn("dbo.Carsuals", "userid", c => c.String(maxLength: 128));
            AddColumn("dbo.centers", "userid", c => c.String(maxLength: 128));
            AddColumn("dbo.Theses", "userid", c => c.String(maxLength: 128));
            AddColumn("dbo.Request_to_edit", "userid", c => c.String(maxLength: 128));
            AddColumn("dbo.contacts", "userid", c => c.String(maxLength: 128));
            AddColumn("dbo.footers", "userid", c => c.String(maxLength: 128));
            AddColumn("dbo.socials", "userid", c => c.String(maxLength: 128));
            CreateIndex("dbo.asks", "userid");
            CreateIndex("dbo.cardinfoes", "userid");
            CreateIndex("dbo.Categories", "userid");
            CreateIndex("dbo.Carsuals", "userid");
            CreateIndex("dbo.centers", "userid");
            CreateIndex("dbo.Theses", "userid");
            CreateIndex("dbo.Request_to_edit", "userid");
            CreateIndex("dbo.contacts", "userid");
            CreateIndex("dbo.footers", "userid");
            CreateIndex("dbo.socials", "userid");
            AddForeignKey("dbo.asks", "userid", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Categories", "userid", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.cardinfoes", "userid", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Carsuals", "userid", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Theses", "userid", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Request_to_edit", "userid", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.centers", "userid", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.contacts", "userid", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.footers", "userid", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.socials", "userid", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.socials", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.footers", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.contacts", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.centers", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.Request_to_edit", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.Theses", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carsuals", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.cardinfoes", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.asks", "userid", "dbo.AspNetUsers");
            DropIndex("dbo.socials", new[] { "userid" });
            DropIndex("dbo.footers", new[] { "userid" });
            DropIndex("dbo.contacts", new[] { "userid" });
            DropIndex("dbo.Request_to_edit", new[] { "userid" });
            DropIndex("dbo.Theses", new[] { "userid" });
            DropIndex("dbo.centers", new[] { "userid" });
            DropIndex("dbo.Carsuals", new[] { "userid" });
            DropIndex("dbo.Categories", new[] { "userid" });
            DropIndex("dbo.cardinfoes", new[] { "userid" });
            DropIndex("dbo.asks", new[] { "userid" });
            DropColumn("dbo.socials", "userid");
            DropColumn("dbo.footers", "userid");
            DropColumn("dbo.contacts", "userid");
            DropColumn("dbo.Request_to_edit", "userid");
            DropColumn("dbo.Theses", "userid");
            DropColumn("dbo.centers", "userid");
            DropColumn("dbo.Carsuals", "userid");
            DropColumn("dbo.Categories", "userid");
            DropColumn("dbo.cardinfoes", "userid");
            DropColumn("dbo.asks", "userid");
        }
    }
}
