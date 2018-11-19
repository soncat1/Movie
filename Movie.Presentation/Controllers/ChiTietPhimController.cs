using Movie.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Presentation.Controllers
{
    public class ChiTietPhimController : Controller
    {
        private FilmService filmService;
        public ChiTietPhimController()
        {
            filmService = new FilmService();
        }
        // GET: ChiTietPhim
        public ActionResult Index(int id)
        {
            return View(filmService.GetFilm(id));
        }
    }
}