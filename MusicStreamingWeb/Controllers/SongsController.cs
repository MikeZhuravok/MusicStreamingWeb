using MusicStreamingWeb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace MusicStreamingWeb.Controllers
{
    [Authorize]
    public class SongsController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            IEnumerable<Song> model;
            using (var client = new HttpClient())
            {
                var uri = new Uri(ApiConnections.siteUrl + "api/song/");

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                model = System.Web.Helpers.Json.Decode<IEnumerable<Song>>(textResult);
            }
            return View(model);
        }

        public async System.Threading.Tasks.Task<ActionResult> Details(int id)
        {
            Song model;
            using (var client = new HttpClient())
            {
                var uri = new Uri(ApiConnections.siteUrl + "api/song/" + id);

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                model = System.Web.Helpers.Json.Decode<Song>(textResult);
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(Song song)
        //{
        //    _db.Songs.Add(song);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public async System.Threading.Tasks.Task<ActionResult> Edit(int id)
        {
            Song model;
            using (var client = new HttpClient())
            {
                var uri = new Uri(ApiConnections.siteUrl + "api/song/" + id);

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                model = System.Web.Helpers.Json.Decode<Song>(textResult);
            }
            return View(model);
        }

        //[HttpPost]
        //public ActionResult Edit(Song song)
        //{
        //    var edit = _db.Songs.FirstOrDefault(i => i.Id == song.Id);
        //    edit.Artist = song.Artist;
        //    edit.Title = song.Title;
        //    edit.Url = song.Url;
        //    edit.Format = song.Format;
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public async System.Threading.Tasks.Task<ActionResult> Delete(int id)
        {
            Song model;
            using (var client = new HttpClient())
            {
                var uri = new Uri(ApiConnections.siteUrl + "api/song/" + id);

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                model = System.Web.Helpers.Json.Decode<Song>(textResult);
            }
            return View(model);
        }

        //[HttpPost]
        //public ActionResult Delete(Song song)
        //{
        //    return RedirectToAction("Index");
        //}
    }
}
