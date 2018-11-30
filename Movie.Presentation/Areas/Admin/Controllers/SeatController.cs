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
    public class SeatController : BaseController
    {
        private SeatService seatService;
        private RoomService roomService;
        private SeatTypeService seatTypeService;
        public SeatController()
        {
            seatService = new SeatService();
            roomService = new RoomService();
            seatTypeService = new SeatTypeService();
        }
        // GET: Admin/Seat
        public ActionResult Index()
        {
            var result = Authenticate();
            if(result==1)
            {
                return View(seatService.GetAll());
            }
            else
            {
                return View("Error404");
            }
        }
        public ActionResult Details(int id)
        {
            var result = Authenticate();
            if(result==1)
            {
                Seat seat = seatService.GetSeat(id);
                if (seat == null)
                {
                    return HttpNotFound();
                }
                return View(seat);
            }
            else
            {
                return View("Error404");
            }
        }
        public ActionResult Create()
        {
            var result = Authenticate();
            if (result==1)
            {
                ViewBag.Room = roomService.GetAll();
                ViewBag.SeatType = seatTypeService.GetAll();
                return View();
            }
            else
            {
                return View("Error404");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Seat seat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    seatService.Add(seat);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể tạo ghế!");
            }
            return View(seat);

        }
        public ActionResult Edit(int id)
        {
            var result = Authenticate();
            if(result==1)
            {
                ViewBag.Room = roomService.GetAll();
                ViewBag.SeatType = seatTypeService.GetAll();
                Seat seat = seatService.GetSeat(id);
                return View(seat);
            }
            else
            {
                return View("Error404");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Seat seat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    seatService.Update(seat);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Không thể thay đổi thông tin ghế!");
            }
            return View(seat);
        }

        public ActionResult Delete(int id)
        {
            var result = Authenticate();
            if(result==1)
            {
                Seat seat = seatService.GetSeat(id);
                return View(seat);
            }
            else
            {
                return View("Error404");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Seat seat)
        {
            try
            {
                seat = seatService.GetSeat(id);
                seatService.Delete(id);
                return RedirectToAction("Index");

            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể xóa ghế");
            }
            return View(seat);
        }
        public int Authenticate()
        {
            var employee = (Employee)Session["Employee"];
            if (employee.Department.Name == "Nhân viên quản lý ghế" || employee.Department.Name == "Tổng giám đốc")
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