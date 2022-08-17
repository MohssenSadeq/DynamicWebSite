namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contacts : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.contacts", "Confirm_contact");
        }
        
        public override void Down()
        {
            AddColumn("dbo.contacts", "Confirm_contact", c => c.String());
        }
    }
}
