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
    public class RoomTypeController : Controller
    {
        private RoomTypeService roomTypeService;
        public RoomTypeController()
        {
            roomTypeService = new RoomTypeService();
        }
        // GET: Admin/RoomType
        public ActionResult Index()
        {
            return View(roomTypeService.GetAll());
        }
        public ActionResult Details(int id)
        {
            RoomType roomType = roomTypeService.GetRoomType(id);
            if (roomType == null)
            {
                return HttpNotFound();
            }
            return View(roomType);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RoomType roomType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    roomTypeService.Add(roomType);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể tạo loại phòng chiếu!");
            }
            return View(roomType);

        }
        public ActionResult Edit(int id)
        {
            RoomType roomType = roomTypeService.GetRoomType(id);
            return View(roomType);
        }

        [HttpPost]
        public ActionResult Edit(RoomType roomType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    roomTypeService.Update(roomType);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Không thể thay đổi thông tin loại phòng chiếu!");
            }
            return View(roomType);
        }

        public ActionResult Delete(int id)
        {
            RoomType roomType = roomTypeService.GetRoomType(id);
            return View(roomType);
        }

        [HttpPost]
        public ActionResult Delete(int id, RoomType roomType)
        {
            try
            {
                roomType = roomTypeService.GetRoomType(id);
                roomTypeService.Delete(id);
                return RedirectToAction("Index");

            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể xóa loại phòng chiếu");
            }
            return View(roomType);
        }
    }
}