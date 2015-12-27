namespace MusicStreamingWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChangesInSongEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "Format", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "Format");
        }
    }
}
