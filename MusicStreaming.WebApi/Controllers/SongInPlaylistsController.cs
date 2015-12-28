using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MusicStreaming.WebApi.Models;

namespace MusicStreaming.WebApi.Controllers
{
    public class SongInPlaylistsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/SongInPlaylists
        public IQueryable<SongInPlaylist> GetSongsInPlaylists()
        {
            return db.SongsInPlaylists;
        }

        // GET: api/SongInPlaylists/5
        [ResponseType(typeof(SongInPlaylist))]
        public IHttpActionResult GetSongInPlaylist(int id)
        {
            SongInPlaylist songInPlaylist = db.SongsInPlaylists.Find(id);
            if (songInPlaylist == null)
            {
                return NotFound();
            }

            return Ok(songInPlaylist);
        }

        public IEnumerable<Song> SongInPlaylistsFromUser(int id)
        {
            var playlist = db.Playlists.FirstOrDefault(i => i.Id == id);
            if (playlist == null)
            {
                return null;
            }
            var model = db.SongsInPlaylists.
                Where(i => i.PlaylistId == playlist.Id).
                Select(i => i.Song).AsEnumerable();
            return model;
        }


        // PUT: api/SongInPlaylists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSongInPlaylist(int id, SongInPlaylist songInPlaylist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != songInPlaylist.Id)
            {
                return BadRequest();
            }

            db.Entry(songInPlaylist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongInPlaylistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SongInPlaylists
        [ResponseType(typeof(SongInPlaylist))]
        public IHttpActionResult PostSongInPlaylist(SongInPlaylist songInPlaylist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SongsInPlaylists.Add(songInPlaylist);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = songInPlaylist.Id }, songInPlaylist);
        }

        // DELETE: api/SongInPlaylists/5
        [ResponseType(typeof(SongInPlaylist))]
        public IHttpActionResult DeleteSongInPlaylist(int id)
        {
            SongInPlaylist songInPlaylist = db.SongsInPlaylists.Find(id);
            if (songInPlaylist == null)
            {
                return NotFound();
            }

            db.SongsInPlaylists.Remove(songInPlaylist);
            db.SaveChanges();

            return Ok(songInPlaylist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SongInPlaylistExists(int id)
        {
            return db.SongsInPlaylists.Count(e => e.Id == id) > 0;
        }
    }
}