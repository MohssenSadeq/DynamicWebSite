namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class center : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.colleges", "center_ID", "dbo.centers");
            DropIndex("dbo.colleges", new[] { "center_ID" });
            DropColumn("dbo.colleges", "centerID");
            RenameColumn(table: "dbo.colleges", name: "center_ID", newName: "centerID");
            AlterColumn("dbo.colleges", "centerID", c => c.Int(nullable: false));
            AlterColumn("dbo.colleges", "centerID", c => c.Int(nullable: false));
            CreateIndex("dbo.colleges", "centerID");
            AddForeignKey("dbo.colleges", "centerID", "dbo.centers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.colleges", "centerID", "dbo.centers");
            DropIndex("dbo.colleges", new[] { "centerID" });
            AlterColumn("dbo.colleges", "centerID", c => c.Int());
            AlterColumn("dbo.colleges", "centerID", c => c.String());
            RenameColumn(table: "dbo.colleges", name: "centerID", newName: "center_ID");
            AddColumn("dbo.colleges", "centerID", c => c.String());
            CreateIndex("dbo.colleges", "center_ID");
            AddForeignKey("dbo.colleges", "center_ID", "dbo.centers", "ID");
        }
    }
}
