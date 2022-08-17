namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.footers", "mainfoot", c => c.String(nullable: false, maxLength: 59));
            AlterColumn("dbo.footers", "title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.footers", "title", c => c.String(nullable: false, maxLength: 59));
            AlterColumn("dbo.footers", "mainfoot", c => c.String(nullable: false));
        }
    }
}
