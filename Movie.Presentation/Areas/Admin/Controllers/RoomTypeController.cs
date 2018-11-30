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
    public class RoomTypeController : BaseController
    {
        private RoomTypeService roomTypeService;
        public RoomTypeController()
        {
            roomTypeService = new RoomTypeService();
        }
        // GET: Admin/RoomType
        public ActionResult Index()
        {
            var result = Authenticate();
            if(result==1)
            {
                return View(roomTypeService.GetAll());
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
                RoomType roomType = roomTypeService.GetRoomType(id);
                if (roomType == null)
                {
                    return HttpNotFound();
                }
                return View(roomType);
            }
            else
            {
                return View("Error404");
            }
        }
        public ActionResult Create()
        {
            var result = Authenticate();
            if (result == 1)
            {
                return View();
            }
            else
            {
                return View("Error404");
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            var result = Authenticate();
            if (result==1)
            {
                RoomType roomType = roomTypeService.GetRoomType(id);
                return View(roomType);
            }
            else
            {
                return View("Error404");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            var result = Authenticate();
            if (result==1)
            {
                RoomType roomType = roomTypeService.GetRoomType(id);
                return View(roomType);
            }
            else
            {
                return View("Error404");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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