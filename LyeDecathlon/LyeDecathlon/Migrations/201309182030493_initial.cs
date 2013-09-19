namespace LyeDecathlon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Athlete",
                c => new
                    {
                        AthleteId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Meter100 = c.Double(nullable: false),
                        Meter1500 = c.Double(nullable: false),
                        Meter400 = c.Double(nullable: false),
                        Hurdles110 = c.Double(nullable: false),
                        LongJump = c.Double(nullable: false),
                        ShotPut = c.Double(nullable: false),
                        HighJump = c.Double(nullable: false),
                        DiscusThrow = c.Double(nullable: false),
                        PoleVault = c.Double(nullable: false),
                        JavelinThrow = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AthleteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Athlete");
            DropTable("dbo.UserProfile");
        }
    }
}
