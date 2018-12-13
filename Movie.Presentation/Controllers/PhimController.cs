using Movie.Models;
using Movie.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Presentation.Controllers
{
    public class PhimController : Controller
    {
        private FilmService filmService;
        private ShowtimeService showtimeService;
        private CinemaService cinemaService;
        private static DateTime currentDate = DateTime.Now;
        private List<DateTime> listDate = new List<DateTime>()
            {
               currentDate, currentDate.AddDays(1),currentDate.AddDays(2),currentDate.AddDays(3),currentDate.AddDays(4)
            };
        public PhimController()
        {
            filmService = new FilmService();
            showtimeService = new ShowtimeService();
            cinemaService = new CinemaService();
        }
        // GET: Phim
        public ActionResult Index()
        {

            ViewBag.Date = listDate.ToList();
            List<Showtime> lstShowtime = showtimeService.GetAll().ToList();
            List<Showtime> lstAvailableShowTime = new List<Showtime>();
            List<Showtime> lstNotAvailableShowTime = new List<Showtime>();
            List<Film> lstShowingFilm = new List<Film>();
            List<Film> lstNotShowFilm = new List<Film>();
            List<Film> lstAllFilm = filmService.GetAll().ToList();
            foreach (DateTime item in listDate)
            {
                foreach (var st in lstShowtime)
                {

                    if (st.ShowDate.ToString().Contains(item.ToString("d")) == true)
                    {
                        lstAvailableShowTime.Add(st);
                    }

                    if (item.AddDays(7).ToString().Contains(st.ShowDate?.ToString("d")) == true)
                    {
                        lstNotAvailableShowTime.Add(st);
                    }

                }
            }

            foreach (var st in lstAvailableShowTime)
            {
                foreach (var film in lstAllFilm)
                {
                    if (lstAvailableShowTime.FirstOrDefault(r => r.FilmId == film.FilmId) != null && lstShowingFilm.Contains(film) == false)
                    {
                        lstShowingFilm.Add(film);
                    }

                }
            }
            foreach (var st in lstNotAvailableShowTime)
            {
                foreach (var film in lstAllFilm)
                {
                    if (lstNotAvailableShowTime.FirstOrDefault(r => r.FilmId == film.FilmId) != null && lstNotShowFilm.Contains(film) == false)
                    {
                        lstNotShowFilm.Add(film);
                    }

                }
            }
            ViewBag.NotShowFilm = lstNotShowFilm;
            return View(lstShowingFilm.ToList());
        }
        public ActionResult GetShowtimeByShowDate(string showDate, int id)
        {
            DateTime currentDate = DateTime.Now;
            Film film = filmService.GetFilm(id);

            DateTime date = DateTime.Parse(showDate);
            List<Showtime> listShowtimes = showtimeService.GetAll().Where(a => a.ShowDate == date && a.FilmId == film.FilmId).OrderBy(a => a.Queue).ToList();
            return PartialView("_GetShowtimeByShowDate", listShowtimes);

        }
        public JsonResult FilmDetail(int showtimeId)
        {
            var showtime = showtimeService.GetShowtime(showtimeId);
            return Json(new { response = true, filmName = showtime.Film.Name, queue = showtime.Queue, cinemaName = showtime.Room.Cinema.Name, cinemaAddress = showtime.Room.Cinema.Address, showDate = showtime.ShowDate }, JsonRequestBehavior.AllowGet);
        }
    }
}