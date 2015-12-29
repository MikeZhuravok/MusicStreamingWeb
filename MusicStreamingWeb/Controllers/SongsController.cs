using MusicStreamingWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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

        //[HttpPost]
        //public async System.Threading.Tasks.Task<ActionResult> Create(Song song)
        //{
        //    var jsonString = System.Web.Helpers.Json.Encode(song);
        //    using (var client = new HttpClient())
        //    {
        //        var uri = new Uri(ApiConnections.siteUrl + "Songs/PostSongByGetMethod?jsonString=" + jsonString);

        //        var response = await client.GetAsync(uri);

        //        string textResult = await response.Content.ReadAsStringAsync();

        //        //var result = System.Web.Helpers.Json.Decode<Song>(textResult);
        //    }
        //    return RedirectToAction("Index");

        //}

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

        [HttpPost]
        public ActionResult Delete(Song song)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiConnections.siteUrl + "api/Songs/" + song.Id);
            //httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "DELETE";

            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            ////{
            ////    streamWriter.Write(Json(song).Data);
            ////    streamWriter.Flush();
            ////    streamWriter.Close();
            //}

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse(); // error 400 not found
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
            return RedirectToAction("Index");
        }
    }
}
