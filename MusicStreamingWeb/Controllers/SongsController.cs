using MusicStreamingWeb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
                var uri = new Uri(ApiConnections.siteUrl + "api/Songs/");

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
                var uri = new Uri(ApiConnections.siteUrl + "api/Songs/" + id);

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

        [HttpPost]
        public ActionResult Create(Song song)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiConnections.siteUrl + "api/Songs/");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(Json(song).Data);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
            return RedirectToAction("Index");
        }

        public async System.Threading.Tasks.Task<ActionResult> Edit(int id)
        {
            Song model;
            using (var client = new HttpClient())
            {
                var uri = new Uri(ApiConnections.siteUrl + "api/Songs/" + id);

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
                var uri = new Uri(ApiConnections.siteUrl + "api/Songs/" + id);

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
