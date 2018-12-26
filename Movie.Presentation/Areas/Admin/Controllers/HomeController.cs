using Movie.Models;
using Movie.Presentation.Areas.Admin.Models;
using Movie.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Presentation.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly TicketService ticketService;
        private readonly CinemaService cinemaService;
        public HomeController()
        {
            ticketService = new TicketService();
            cinemaService = new CinemaService();
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            var result = Authenticate();
            if (result == 1)
            {
                return View();
            }

            else
                return View("Error404");
        }
        public int Authenticate()
        {
            var employee = (Employee)Session["Employee"];
            if (employee.Department.Name == "Tổng giám đốc")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public JsonResult GetJsonData()
        {
            var cinemas = cinemaService.GetAll();
            var quyOne = ticketService.GetAll().Where(n => n.DateCreate.Month == 1 || n.DateCreate.Month == 2 || n.DateCreate.Month == 3);
            var quyTwo = ticketService.GetAll().Where(n => n.DateCreate.Month == 4 || n.DateCreate.Month == 5 || n.DateCreate.Month == 6);
            var quyThree = ticketService.GetAll().Where(n => n.DateCreate.Month == 7 || n.DateCreate.Month == 8 || n.DateCreate.Month == 9);
            var quyFour = ticketService.GetAll().Where(n => n.DateCreate.Month == 10 || n.DateCreate.Month == 11 || n.DateCreate.Month == 12);
            List<string> cinemaName = new List<string>();
            List<double> totalMoney1 = new List<double>();
            List<double> totalMoney2 = new List<double>();
            foreach (var item in cinemas)
            {
                cinemaName.Add(item.Address);
                if (item.CinemaId == 1)
                {
                    totalMoney1.Add(quyOne.Where(n => n.Showtime.Room.CinemaId == 1).Sum(n => n.Price));
                    totalMoney1.Add(quyTwo.Where(n => n.Showtime.Room.CinemaId == 1).Sum(n => n.Price));
                    totalMoney1.Add(quyThree.Where(n => n.Showtime.Room.CinemaId == 1).Sum(n => n.Price));
                    totalMoney1.Add(quyFour.Where(n => n.Showtime.Room.CinemaId == 1).Sum(n => n.Price));
                }
                else
                {
                    totalMoney2.Add(quyOne.Where(n => n.Showtime.Room.CinemaId == 2).Sum(n => n.Price));
                    totalMoney2.Add(quyTwo.Where(n => n.Showtime.Room.CinemaId == 2).Sum(n => n.Price));
                    totalMoney2.Add(quyThree.Where(n => n.Showtime.Room.CinemaId == 2).Sum(n => n.Price));
                    totalMoney2.Add(quyFour.Where(n => n.Showtime.Room.CinemaId == 2).Sum(n => n.Price));
                }

            }
            return Json(new { Name = cinemaName, TotalMoney1 = totalMoney1, TotalMoney2 = totalMoney2 }, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetJsonData()
        //{
        //    var cinemas = cinemaService.GetAll();
        //    var monday = ticketService.GetAll().Where(n => n.DateCreate.DayOfWeek == DayOfWeek.Monday);
        //    var tuesday = ticketService.GetAll().Where(n => n.DateCreate.DayOfWeek== DayOfWeek.Tuesday);
        //    var wednesday = ticketService.GetAll().Where(n => n.DateCreate.DayOfWeek == DayOfWeek.Wednesday);
        //    var thursday = ticketService.GetAll().Where(n => n.DateCreate.DayOfWeek==DayOfWeek.Thursday);
        //    var friday = ticketService.GetAll().Where(n => n.DateCreate.DayOfWeek==DayOfWeek.Friday);
        //    var saturday = ticketService.GetAll().Where(n => n.DateCreate.DayOfWeek==DayOfWeek.Saturday);
        //    var sunday = ticketService.GetAll().Where(n => n.DateCreate.DayOfWeek==DayOfWeek.Sunday);
        //    List<string> cinemaName = new List<string>();
        //    List<double> totalMoney1 = new List<double>();
        //    List<double> totalMoney2 = new List<double>();
        //    foreach (var item in cinemas)
        //    {
        //        cinemaName.Add(item.Address);
        //        if (item.CinemaId == 1)
        //        {
        //            totalMoney1.Add(monday.Where(n => n.Showtime.Room.CinemaId == 1).Sum(n => n.Price));
        //            totalMoney1.Add(tuesday.Where(n => n.Showtime.Room.CinemaId == 1).Sum(n => n.Price));
        //            totalMoney1.Add(wednesday.Where(n => n.Showtime.Room.CinemaId == 1).Sum(n => n.Price));
        //            totalMoney1.Add(thursday.Where(n => n.Showtime.Room.CinemaId == 1).Sum(n => n.Price));
        //            totalMoney1.Add(friday.Where(n => n.Showtime.Room.CinemaId ==1).Sum(n => n.Price));
        //            totalMoney1.Add(saturday.Where(n => n.Showtime.Room.CinemaId == 1).Sum(n => n.Price));
        //            totalMoney1.Add(sunday.Where(n => n.Showtime.Room.CinemaId == 1).Sum(n => n.Price));


        //        }
        //        else
        //        {
        //            totalMoney2.Add(monday.Where(n => n.Showtime.Room.CinemaId == 2).Sum(n => n.Price));
        //            totalMoney2.Add(tuesday.Where(n => n.Showtime.Room.CinemaId == 2).Sum(n => n.Price));
        //            totalMoney2.Add(wednesday.Where(n => n.Showtime.Room.CinemaId == 2).Sum(n => n.Price));
        //            totalMoney2.Add(thursday.Where(n => n.Showtime.Room.CinemaId == 2).Sum(n => n.Price));
        //            totalMoney2.Add(friday.Where(n => n.Showtime.Room.CinemaId == 2).Sum(n => n.Price));
        //            totalMoney2.Add(saturday.Where(n => n.Showtime.Room.CinemaId == 2).Sum(n => n.Price));
        //            totalMoney2.Add(sunday.Where(n => n.Showtime.Room.CinemaId == 2).Sum(n => n.Price));
        //        }

        //    }
        //    return Json(new { Name = cinemaName, TotalMoney1 = totalMoney1, TotalMoney2 = totalMoney2 }, JsonRequestBehavior.AllowGet);
        //}

    }
}