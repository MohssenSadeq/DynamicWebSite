namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdse2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.centers", "classname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.centers", "classname", c => c.Int(nullable: false));
        }
    }
}
