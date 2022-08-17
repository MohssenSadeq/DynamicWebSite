namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class msta2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.staffs", "collegesid", "dbo.colleges");
            DropIndex("dbo.staffs", new[] { "collegesid" });
            RenameColumn(table: "dbo.staffs", name: "collegesid", newName: "college_id");
            AddColumn("dbo.staffs", "phone_num", c => c.String());
            AlterColumn("dbo.staffs", "college_id", c => c.Int());
            CreateIndex("dbo.staffs", "college_id");
            AddForeignKey("dbo.staffs", "college_id", "dbo.colleges", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.staffs", "college_id", "dbo.colleges");
            DropIndex("dbo.staffs", new[] { "college_id" });
            AlterColumn("dbo.staffs", "college_id", c => c.Int(nullable: false));
            DropColumn("dbo.staffs", "phone_num");
            RenameColumn(table: "dbo.staffs", name: "college_id", newName: "collegesid");
            CreateIndex("dbo.staffs", "collegesid");
            AddForeignKey("dbo.staffs", "collegesid", "dbo.colleges", "id", cascadeDelete: true);
        }
    }
}
