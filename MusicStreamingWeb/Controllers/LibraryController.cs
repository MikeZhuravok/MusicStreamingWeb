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
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Library
        public ActionResult Index()
        {
            var model = _db.Songs.ToList();
            return View(model);
        }

    }
}