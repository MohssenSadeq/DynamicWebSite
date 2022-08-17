namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gamil : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "nikname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "nikname");
        }
    }
}
