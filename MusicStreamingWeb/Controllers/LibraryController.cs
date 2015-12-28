using MusicStreamingWeb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace MusicStreamingWeb.Controllers
{
    public class LibraryController : Controller
    {
        // GET: Library
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

    }
}