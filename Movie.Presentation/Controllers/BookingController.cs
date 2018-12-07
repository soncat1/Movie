using Movie.Presentation.Models;
using Movie.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Presentation.Controllers
{
    public class BookingController : Controller
    {
        private SeatService seatService;

        public BookingController()
        {
            seatService = new SeatService();
        }
        // GET: Booking
        public ActionResult Index()
        {
            var seatVM = new SeatViewModel()
            {
                SeatModel = seatService.GetAll().ToList()
            };
            ViewBag.MaxColumn = seatService.GetAll().Max(c=>Convert.ToInt32(c.ColumnSeat)).ToString();
            return View(seatVM);
        }
    }
}