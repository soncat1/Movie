using Movie.Models;
using Movie.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Presentation.Controllers
{
    public class LichChieuController : Controller
    {
        // GET: LichChieu
        private FilmService filmService;
        private ShowtimeService showtimeService;
        private RoomService roomService;
        private SeatService seatService;
        private CinemaService cinemaService;
        public LichChieuController()
        {
            filmService = new FilmService();
            showtimeService = new ShowtimeService();
            roomService = new RoomService();
            seatService = new SeatService();
            cinemaService = new CinemaService();
        }

        public ActionResult Index()
        {
            DateTime currentDate = DateTime.Now;


            List<DateTime> listDate = new List<DateTime>()
            {
               currentDate, currentDate.AddDays(1),currentDate.AddDays(2),currentDate.AddDays(3),currentDate.AddDays(4)
            };

            ViewBag.Date = listDate.ToList();
            ViewBag.Film = filmService.GetAll();
            ViewBag.Showtime = showtimeService.GetAll();
            ViewBag.Room = roomService.GetAll();
            ViewBag.Seat = seatService.GetAll();

            return View();
        }

        [OutputCache(Duration = 60)]
        public ActionResult GetFilmByShowDate(string showDate)
        {
            List<Film> allFilm = filmService.GetAll().ToList();
            List<Film> film = new List<Film>();
            DateTime date = DateTime.Parse(showDate);
            List<Showtime> listShowtimes = showtimeService.GetAll().Where(a => a.ShowDate == date).OrderBy(a => a.Queue).ToList();
            foreach (var item in allFilm)
            {
                if (listShowtimes.FirstOrDefault(a => a.FilmId == item.FilmId) != null && film.Contains(item) == false)
                {
                    film.Add(item);
                }
            }
            ViewBag.Film = film;
            return PartialView("_GetFilmByShowDate", listShowtimes);
        }
        public ActionResult GetCinemaDropdown()
        {
            ViewBag.Cinema = cinemaService.GetAll();
            return PartialView("_Navigation", ViewBag.Cinema);
        }
        public JsonResult FilmDetail(int showtimeId)
        {
            var showtime = showtimeService.GetShowtime(showtimeId);
            return Json(new { response = true, filmName = showtime.Film.Name, queue = showtime.Queue, cinemaName = showtime.Room.Cinema.Name, cinemaAddress = showtime.Room.Cinema.Address, showDate = showtime.ShowDate }, JsonRequestBehavior.AllowGet);
        }
    }
}