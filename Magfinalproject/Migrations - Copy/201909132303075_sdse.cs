namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdse : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "nikname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "nikname", c => c.String());
        }
    }
}
