namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jkj : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.cardinfoes", "userid", c => c.String(maxLength: 128));
            CreateIndex("dbo.cardinfoes", "userid");
            AddForeignKey("dbo.cardinfoes", "userid", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cardinfoes", "userid", "dbo.AspNetUsers");
            DropIndex("dbo.cardinfoes", new[] { "userid" });
            AlterColumn("dbo.cardinfoes", "userid", c => c.String());
        }
    }
}
