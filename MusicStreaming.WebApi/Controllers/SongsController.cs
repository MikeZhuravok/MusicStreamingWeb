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
using System.Web.Http.Results;

namespace MusicStreaming.WebApi.Controllers
{
    public class SongsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //public IQueryable<Song> GetSongs()
        //{
        //    return db.Songs;
        //}

        public IEnumerable<Song> GetSongs()
        {
            return db.Songs.AsEnumerable();
        }

        [ResponseType(typeof(Song))]
        public IHttpActionResult GetSong(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return NotFound();
            }

            return Ok(song);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutSong(Song song) //toDo
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != song.Id)
            //{
            //    return BadRequest();
            //}
            var toEdit = db.Songs.FirstOrDefault(i => i.Id == song.Id);
            db.Entry(song).State = EntityState.Modified;
            toEdit.Artist = song.Artist;
            toEdit.Format = song.Format;
            toEdit.Title = song.Title;
            toEdit.Url = song.Url;
            //try
            //{
            db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!SongExists(song.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return Redirect(@"http://localhost:3681/Songs/");
        }

        // POST: api/Songs
        [ResponseType(typeof(Song))]
        public RedirectResult PostSong(Song song)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            song.Id = -1;

            db.Songs.Add(song);
            db.SaveChanges();

            return Redirect(@"http://localhost:3681/Songs/");
        }


        // DELETE: api/Songs/5
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