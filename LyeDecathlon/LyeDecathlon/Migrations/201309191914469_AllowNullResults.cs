namespace LyeDecathlon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowNullResults : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Athlete", "Meter100", c => c.Double());
            AlterColumn("dbo.Athlete", "Meter1500", c => c.Double());
            AlterColumn("dbo.Athlete", "Meter400", c => c.Double());
            AlterColumn("dbo.Athlete", "Hurdles110", c => c.Double());
            AlterColumn("dbo.Athlete", "LongJump", c => c.Double());
            AlterColumn("dbo.Athlete", "ShotPut", c => c.Double());
            AlterColumn("dbo.Athlete", "HighJump", c => c.Double());
            AlterColumn("dbo.Athlete", "DiscusThrow", c => c.Double());
            AlterColumn("dbo.Athlete", "PoleVault", c => c.Double());
            AlterColumn("dbo.Athlete", "JavelinThrow", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Athlete", "JavelinThrow", c => c.Double(nullable: false));
            AlterColumn("dbo.Athlete", "PoleVault", c => c.Double(nullable: false));
            AlterColumn("dbo.Athlete", "DiscusThrow", c => c.Double(nullable: false));
            AlterColumn("dbo.Athlete", "HighJump", c => c.Double(nullable: false));
            AlterColumn("dbo.Athlete", "ShotPut", c => c.Double(nullable: false));
            AlterColumn("dbo.Athlete", "LongJump", c => c.Double(nullable: false));
            AlterColumn("dbo.Athlete", "Hurdles110", c => c.Double(nullable: false));
            AlterColumn("dbo.Athlete", "Meter400", c => c.Double(nullable: false));
            AlterColumn("dbo.Athlete", "Meter1500", c => c.Double(nullable: false));
            AlterColumn("dbo.Athlete", "Meter100", c => c.Double(nullable: false));
        }
    }
}
