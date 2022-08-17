namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mainfoot : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.footers", "mainfoot", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.footers", "mainfoot", c => c.Int(nullable: false));
        }
    }
}
