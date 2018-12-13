using Movie.Models;
using Movie.Presentation.Models;
using Movie.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Movie.Presentation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private FilmService filmService;
        private ShowtimeService showtimeService;
        private RoomService roomService;
        private SeatService seatService;
        private CinemaService cinemaService;
        public HomeController()
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

        [OutputCache(Duration =60)]
        public ActionResult GetFilmByShowDate(string showDate)
        {
            List<Film> allFilm = filmService.GetAll().ToList();
            List<Film> film = new List<Film>();
            DateTime date = DateTime.Parse(showDate);
            List<Showtime> listShowtimes = showtimeService.GetAll().Where(a => a.ShowDate == date).OrderBy(a=>a.Queue).ToList();
            foreach (var item in allFilm)
            {
                if (listShowtimes.FirstOrDefault(a => a.FilmId == item.FilmId) != null&&film.Contains(item)==false)
                {
                    film.Add(item);
                }
            }
            ViewBag.Film = film;
            return PartialView("_GetFilmByShowDate",listShowtimes);
        }
        public ActionResult GetCinemaDropdown()
        {
            ViewBag.Cinema = cinemaService.GetAll();
            return PartialView("_Navigation", ViewBag.Cinema);
        }
        //public JsonResult FilmDetail(int filmId,int roomId,int queue)
        //{
        //    var cinemaName = cinemaService.GetAll().Select(n => n.Name).FirstOrDefault();
        //    var showtimeName = showtimeService.GetAll().Where(n => n.FilmId == filmId && n.RoomId == roomId && n.Queue == queue).Select(n => n.ShowDate).FirstOrDefault();
        //    return Json(new { response = true, CinemaName = cinemaName, ShowtimeName = showtimeName },JsonRequestBehavior.AllowGet);
        //}
        public JsonResult FilmDetail(int showtimeId)
        {
            var showtime = showtimeService.GetShowtime(showtimeId);
            return Json(new { response = true,filmName=showtime.Film.Name,queue=showtime.Queue, cinemaName = showtime.Room.Cinema.Name,cinemaAddress=showtime.Room.Cinema.Address, showDate = showtime.ShowDate }, JsonRequestBehavior.AllowGet);
        }
    }
}