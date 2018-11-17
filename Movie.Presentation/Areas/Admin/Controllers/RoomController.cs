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
    public class RoomController : Controller
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
            return View(roomService.GetAll());
        }
        public ActionResult Details(int id)
        {
            Room room = roomService.GetRoom(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }
        public ActionResult Create()
        {
            ViewBag.Cinema = cinemaService.GetAll();
            ViewBag.RoomType = roomTypeService.GetAll();
            return View();
        }
        [HttpPost]
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
            ViewBag.Cinema = cinemaService.GetAll();
            ViewBag.RoomType = roomTypeService.GetAll();
            Room room = roomService.GetRoom(id);
            return View(room);
        }

        [HttpPost]
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
            Room room = roomService.GetRoom(id);
            return View(room);
        }

        [HttpPost]
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
    }
}