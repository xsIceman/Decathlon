namespace LyeDecathlon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decathlonName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Decathlon", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Decathlon", "Name");
        }
    }
}
