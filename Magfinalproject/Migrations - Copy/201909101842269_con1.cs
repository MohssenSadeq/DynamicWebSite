namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class con1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.contacts", "telephone", c => c.String());
            AlterColumn("dbo.contacts", "phone_num", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.contacts", "phone_num", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.contacts", "telephone", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
