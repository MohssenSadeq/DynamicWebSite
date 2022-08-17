namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class msta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.asks", "phone_num", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.asks", "phone_num");
        }
    }
}
