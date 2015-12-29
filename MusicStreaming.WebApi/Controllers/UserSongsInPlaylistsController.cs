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
    public class UserSongsInPlaylistsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/UserSongsInPlaylists
        public IQueryable<Song> GetSongs()
        {
            return db.Songs;
        }

        // GET: api/UserSongsInPlaylists/5
        [ResponseType(typeof(Song))]
        public IEnumerable<Song> SongInPlaylistsFromUser(string id)
        {
            var playlist = db.Playlists.FirstOrDefault(i => i.UserId == id);
            if (playlist == null)
            {
                return null;
            }
            var model = db.SongsInPlaylists.
                Where(i => i.PlaylistId == playlist.Id).
                Select(i => i.Song).AsEnumerable();
            return model;
        }

        // PUT: api/UserSongsInPlaylists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSong(int id, Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != song.Id)
            {
                return BadRequest();
            }

            db.Entry(song).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
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

        // POST: api/UserSongsInPlaylists
        [ResponseType(typeof(Song))]
        public IHttpActionResult PostSong(Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Songs.Add(song);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = song.Id }, song);
        }

        // DELETE: api/UserSongsInPlaylists/5
        [ResponseType(typeof(Song))]
        public IHttpActionResult DeleteSong(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return NotFound();
            }

            db.Songs.Remove(song);
            db.SaveChanges();

            return Ok(song);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SongExists(int id)
        {
            return db.Songs.Count(e => e.Id == id) > 0;
        }
    }
}