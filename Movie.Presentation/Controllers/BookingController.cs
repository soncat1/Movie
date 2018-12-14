using Movie.Models;
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
        private ShowtimeService showtimeService;
        private TicketService ticketService;
        private RoomService roomService;

        public BookingController()
        {
            seatService = new SeatService();
            showtimeService = new ShowtimeService();
            ticketService = new TicketService();
            roomService = new RoomService();
        }
        // GET: Booking
        public ActionResult Index(int showtimeId)
        {
            Session["CurrentUrl"] = Request.Url;
            if (Session["Customer"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var roomId = showtimeService.GetShowtime(showtimeId).RoomId;
                var seatVM = new SeatViewModel()
                {
                    SeatModel = seatService.GetAll().Where(n=>n.RoomId==roomId).ToList()
                };
                ViewBag.MaxColumn = seatService.GetAll().Max(c => Convert.ToInt32(c.ColumnSeat)).ToString();
                ViewBag.Showtime = showtimeService.GetAll().Where(n => n.ShowtimeId == showtimeId).ToList();
                ViewBag.ShowtimeId = showtimeId;
                return View(seatVM);
            }


        }
        [HttpPost]
        public ActionResult CreateTicket(int showtimeId, int[] lstCheckedSeat)
        {
            var user = Session["Customer"] as Customer;
            if (ModelState.IsValid && user != null)
            {
                foreach (int item in lstCheckedSeat)
                {
                    ticketService.Add(new Ticket { ShowtimeId = showtimeId, SeatId = item, Price = double.Parse(seatService.GetSeat(item).SeatType.Description), CustomerId = user.CustomerId, DateCreate = DateTime.Now });
                }
                return Json(new { Messenger = "Bạn đã đặt vé thành công!", Status = "success" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { Messenger = "Đặt vé thất bại!", Status = "failed" }, JsonRequestBehavior.AllowGet);

            }
        }
        public JsonResult GetBoughtSeat(int showtimeId)
        {
            var seats = ticketService.GetAll().Where(n => n.ShowtimeId == showtimeId).Select(n => n.SeatId).ToList();
            return Json(seats, JsonRequestBehavior.AllowGet);
        }
    }
}