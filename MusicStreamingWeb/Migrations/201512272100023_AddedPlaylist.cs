namespace MusicStreamingWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPlaylist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SongInPlaylists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaylistId = c.Int(nullable: false),
                        SongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Playlists", t => t.PlaylistId, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .Index(t => t.PlaylistId)
                .Index(t => t.SongId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Playlists", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SongInPlaylists", "SongId", "dbo.Songs");
            DropForeignKey("dbo.SongInPlaylists", "PlaylistId", "dbo.Playlists");
            DropIndex("dbo.SongInPlaylists", new[] { "SongId" });
            DropIndex("dbo.SongInPlaylists", new[] { "PlaylistId" });
            DropIndex("dbo.Playlists", new[] { "UserId" });
            DropTable("dbo.SongInPlaylists");
            DropTable("dbo.Playlists");
        }
    }
}
