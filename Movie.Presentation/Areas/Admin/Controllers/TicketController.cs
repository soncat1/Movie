using Movie.Models;
using Movie.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Presentation.Areas.Admin.Controllers
{
    public class TicketController : BaseController
    {
        private TicketService ticketService;
        private ShowtimeService showtimeService;
        private SeatService seatService;
        private CustomerService customerService;
        public TicketController()
        {
            ticketService = new TicketService();
            showtimeService = new ShowtimeService();
            seatService = new SeatService();
            customerService = new CustomerService();
        }
        // GET: Admin/Ticket
        public ActionResult Index()
        {
            var result = Authenticate();
            if (result == 1)
                return View(ticketService.GetAll());
            else
                return View("Error404");
        }
        public ActionResult Details(int id)
        {
            var result = Authenticate();
            if (result == 1)
            {
                Ticket ticket = ticketService.GetTicket(id);
                if (ticket == null)
                {
                    return HttpNotFound();
                }
                return View(ticket);
            }
            else
                return View("Error404");

        }
        public ActionResult Edit(int id)
        {
            ViewBag.Showtime = showtimeService.GetAll().ToList();
            ViewBag.Seat = seatService.GetAll().ToList();
            ViewBag.Customer = customerService.GetAll().ToList();
            var result = Authenticate();
            if (result == 1)
            {
                Ticket ticket = ticketService.GetTicket(id);
                return View(ticket);
            }
            else
            {
                return View("Error404");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ticketService.Update(ticket);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Không thể thay đổi thông tin vé!");
            }
            return View(ticket);
        }
        public ActionResult Delete(int id)
        {
            var result = Authenticate();
            if (result == 1)
            {
                Ticket ticket = ticketService.GetTicket(id);
                return View(ticket);
            }
            else
            {
                return View("Error404");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Ticket ticket)
        {
            try
            {
                ticket = ticketService.GetTicket(id);
                ticketService.Delete(id);
                return RedirectToAction("Index");

            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể xóa vé");
            }
            return View(ticket);
        }
        public int Authenticate()
        {
            var employee = (Employee)Session["Employee"];
            if (employee.Department.Name == "Nhân viên quản lý vé" || employee.Department.Name == "Tổng giám đốc")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}