using MusicStreamingWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStreamingWeb.Controllers
{
    public class LibraryController : Controller
    {
        // GET: Library
        public ActionResult Index()
        {
            //List<SongOnDisk> songs = new List<SongOnDisk>();
            ////string filepath = HttpContext.Request.PhysicalApplicationPath;
            ////String path = HttpContext.Server.MapPath("Content/SoundLibrary/01 Maps.m4a");
            //songs.Add(new SongOnDisk { Path = "/Content/SoundLibrary/oxxxy.mp3", Id = 0, Format="mp3" });
            ////ViewBag.JPlayer = true;
            //return View(songs);
            return View();
        }
    }
}