using MusicStreamingWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStreamingWeb.Controllers
{
    [Authorize]
    public class SongsController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var model = _db.Songs.AsEnumerable();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _db.Songs.FirstOrDefault(i => i.Id == id);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Song song)
        {
            _db.Songs.Add(song);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            var model = _db.Songs.FirstOrDefault(i => i.Id == id);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Edit(Song song)
        {
            var edit = _db.Songs.FirstOrDefault(i => i.Id == song.Id);
            edit.Artist = song.Artist;
            edit.Title = song.Title;
            edit.Url = song.Url;
            edit.Format = song.Format;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var model = _db.Songs.FirstOrDefault(i => i.Id == id);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Delete(Song song)
        { 
                return RedirectToAction("Index");            
        }
    }
}
