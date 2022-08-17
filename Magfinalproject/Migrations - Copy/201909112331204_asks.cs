namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.asks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fname = c.String(nullable: false),
                        lname = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        subject = c.String(nullable: false, maxLength: 59),
                        question = c.String(nullable: false, maxLength: 59),
                        answer = c.String(),
                        priority = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.asks");
        }
    }
}
