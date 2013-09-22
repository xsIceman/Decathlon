namespace LyeDecathlon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class log : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        AthleteName = c.String(),
                        Event = c.String(),
                        Result = c.Double(),
                    })
                .PrimaryKey(t => t.LogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Log");
        }
    }
}
