namespace LyeDecathlon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class logTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Log", "LogTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Log", "LogTime");
        }
    }
}
