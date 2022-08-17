namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.agents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PointName = c.String(),
                        regon = c.String(),
                        date = c.DateTime(nullable: false),
                        userid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.userid)
                .Index(t => t.userid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.agents", "userid", "dbo.AspNetUsers");
            DropIndex("dbo.agents", new[] { "userid" });
            DropTable("dbo.agents");
        }
    }
}
