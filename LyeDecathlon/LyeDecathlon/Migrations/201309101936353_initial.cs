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
                    })
                .PrimaryKey(t => t.AthleteId);
            
            CreateTable(
                "dbo.EventResult",
                c => new
                    {
                        EventResultId = c.Int(nullable: false, identity: true),
                        Result = c.Double(nullable: false),
                        Score = c.Double(nullable: false),
                        Decathlon_DecathlonId = c.Int(),
                        Event_EventId = c.Int(),
                        Athlete_AthleteId = c.Int(),
                    })
                .PrimaryKey(t => t.EventResultId)
                .ForeignKey("dbo.Decathlon", t => t.Decathlon_DecathlonId)
                .ForeignKey("dbo.Event", t => t.Event_EventId)
                .ForeignKey("dbo.Athlete", t => t.Athlete_AthleteId)
                .Index(t => t.Decathlon_DecathlonId)
                .Index(t => t.Event_EventId)
                .Index(t => t.Athlete_AthleteId);
            
            CreateTable(
                "dbo.Decathlon",
                c => new
                    {
                        DecathlonId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.DecathlonId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Unit = c.String(),
                        A = c.Double(nullable: false),
                        B = c.Double(nullable: false),
                        C = c.Double(nullable: false),
                        Decathlon_DecathlonId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Decathlon", t => t.Decathlon_DecathlonId)
                .Index(t => t.Decathlon_DecathlonId);
            
            CreateTable(
                "dbo.DecathlonAthlete",
                c => new
                    {
                        Decathlon_DecathlonId = c.Int(nullable: false),
                        Athlete_AthleteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Decathlon_DecathlonId, t.Athlete_AthleteId })
                .ForeignKey("dbo.Decathlon", t => t.Decathlon_DecathlonId, cascadeDelete: true)
                .ForeignKey("dbo.Athlete", t => t.Athlete_AthleteId, cascadeDelete: true)
                .Index(t => t.Decathlon_DecathlonId)
                .Index(t => t.Athlete_AthleteId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.DecathlonAthlete", new[] { "Athlete_AthleteId" });
            DropIndex("dbo.DecathlonAthlete", new[] { "Decathlon_DecathlonId" });
            DropIndex("dbo.Event", new[] { "Decathlon_DecathlonId" });
            DropIndex("dbo.EventResult", new[] { "Athlete_AthleteId" });
            DropIndex("dbo.EventResult", new[] { "Event_EventId" });
            DropIndex("dbo.EventResult", new[] { "Decathlon_DecathlonId" });
            DropForeignKey("dbo.DecathlonAthlete", "Athlete_AthleteId", "dbo.Athlete");
            DropForeignKey("dbo.DecathlonAthlete", "Decathlon_DecathlonId", "dbo.Decathlon");
            DropForeignKey("dbo.Event", "Decathlon_DecathlonId", "dbo.Decathlon");
            DropForeignKey("dbo.EventResult", "Athlete_AthleteId", "dbo.Athlete");
            DropForeignKey("dbo.EventResult", "Event_EventId", "dbo.Event");
            DropForeignKey("dbo.EventResult", "Decathlon_DecathlonId", "dbo.Decathlon");
            DropTable("dbo.DecathlonAthlete");
            DropTable("dbo.Event");
            DropTable("dbo.Decathlon");
            DropTable("dbo.EventResult");
            DropTable("dbo.Athlete");
            DropTable("dbo.UserProfile");
        }
    }
}
