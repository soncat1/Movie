﻿using Movie.Models;
using Movie.Presentation.Models;
using Movie.Service;
using System;
using System.Collections.Generic;
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
        private readonly NewService newService;
        private TicketService ticketService;
        public HomeController()
        {
            filmService = new FilmService();
            showtimeService = new ShowtimeService();
            roomService = new RoomService();
            seatService = new SeatService();
            cinemaService = new CinemaService();
            ticketService = new TicketService();
            newService = new NewService();
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

        public ActionResult GetFilmByShowDate(string showDate)
        {
            var cinema = ((Cinema)(Session["Cinema"])).CinemaId;
            Dictionary<int,int> lstSeats = new Dictionary<int,int>();
            List<Film> allFilm = filmService.GetAll().ToList();
            List<Film> film = new List<Film>();
            DateTime date = DateTime.Parse(showDate);
            List<Showtime> listShowtimes = showtimeService.GetAll().Where(a => a.ShowDate == date && a.Room.CinemaId==cinema).OrderBy(a => a.Queue).ToList();
            foreach (Film item in allFilm)
            {
                if (listShowtimes.FirstOrDefault(a => a.FilmId == item.FilmId) != null && film.Contains(item) == false)
                {
                    film.Add(item);
                }
            }
            foreach (var item in listShowtimes)
            {
                var seats = seatService.GetAll().Where(n=>n.RoomId==item.RoomId).Count()- ticketService.GetAll().Where(n => n.ShowtimeId == item.ShowtimeId).Count();
                lstSeats.Add(item.ShowtimeId,seats);
            }
            ViewBag.Seat = lstSeats;
            ViewBag.Film = film;
            return PartialView("_GetFilmByShowDate", listShowtimes);
        }
        public ActionResult GetCinemaDropdown()
        {
            if(Session["Cinema"] == null)
            {
                Session["Cinema"] = cinemaService.GetCinema(1);
            }
            ViewBag.Cinema = cinemaService.GetAll();
            return PartialView("_Navigation", ViewBag.Cinema);
        }
        public JsonResult FilmDetail(int showtimeId)
        {
            var showtime = showtimeService.GetShowtime(showtimeId);
            return Json(new { response = true, filmName = showtime.Film.Name, queue = showtime.Queue, cinemaName = showtime.Room.Cinema.Name, cinemaAddress = showtime.Room.Cinema.Address, showDate = showtime.ShowDate }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CinemaDetail()
        {
            var cinema = Session["Cinema"] as Cinema;           
            ViewBag.CinemaInfo = $"{cinema.Name}--{cinema.Address}";
            return View();
        }
        public ActionResult PriceTicket()
        {
            var cinema = Session["Cinema"] as Cinema;
            ViewBag.PriceTicketInfo = $"Giá vé xem phim rạp: {cinema.Name}--{cinema.Address}";
            return View();
        }
        public ActionResult CinemaNews()
        {
            var data = new NewsModel();
            data.News = newService.GetAll().ToList();
            return View(data);
        }
        public ActionResult GetSessionCinema(int id)
        {
            Session["Cinema"] = cinemaService.GetCinema(id);
            var returnUrl = Request.UrlReferrer.ToString();
            return Json(returnUrl, JsonRequestBehavior.AllowGet);
        }
    }
}