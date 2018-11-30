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
    public class RoomController : BaseController
    {
        private RoomService roomService;
        private CinemaService cinemaService;
        private RoomTypeService roomTypeService;
        public RoomController()
        {
            roomService = new RoomService();
            cinemaService = new CinemaService();
            roomTypeService = new RoomTypeService();
        }
        // GET: Admin/Room
        public ActionResult Index()
        {
            var result = Authenticate();
            if(result==1)
            {
                return View(roomService.GetAll());
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
                Room room = roomService.GetRoom(id);
                if (room == null)
                {
                    return HttpNotFound();
                }
                return View(room);
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
                ViewBag.Cinema = cinemaService.GetAll();
                ViewBag.RoomType = roomTypeService.GetAll();
                return View();
            }
            else
            {
                return View("Error404");
            }
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    roomService.Add(room);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể tạo phòng chiếu!");
            }
            return View(room);

        }
        public ActionResult Edit(int id)
        {
            var result = Authenticate();
            if(result==1)
            {
                ViewBag.Cinema = cinemaService.GetAll();
                ViewBag.RoomType = roomTypeService.GetAll();
                Room room = roomService.GetRoom(id);
                return View(room);
            }
            else
            {
                return View("Error404");
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Room room)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    roomService.Update(room);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Không thể thay đổi thông tin phòng chiếu!");
            }
            return View(room);
        }

        public ActionResult Delete(int id)
        {
            var result = Authenticate();
            if(result==1)
            {
                Room room = roomService.GetRoom(id);
                return View(room);
            }
            else
            {
                return View("Error404");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Room room)
        {
            try
            {
                room = roomService.GetRoom(id);
                roomService.Delete(id);
                return RedirectToAction("Index");

            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể xóa phòng chiếu");
            }
            return View(room);
        }
        public int Authenticate()
        {
            var employee = (Employee)Session["Employee"];
            if (employee.Department.Name == "Nhân viên quản lý phòng chiếu" || employee.Department.Name == "Tổng giám đốc")
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