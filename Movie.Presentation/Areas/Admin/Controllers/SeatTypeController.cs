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
    public class SeatTypeController : BaseController
    {
        private SeatTypeService seatTypeService;
        public SeatTypeController()
        {
            seatTypeService = new SeatTypeService();
        }
        // GET: Admin/SeatType
        public ActionResult Index()
        {
            var result = Authenticate();
            if (result==1)
            {
                return View(seatTypeService.GetAll());
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
                SeatType seatType = seatTypeService.GetSeatType(id);
                if (seatType == null)
                {
                    return HttpNotFound();
                }
                return View(seatType);
            }
            else
            {
                return View("Error404");
            }
            
        }
        public ActionResult Create()
        {
            var result = Authenticate();
            if(result==1)
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
        public ActionResult Create(SeatType seatType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    seatTypeService.Add(seatType);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể tạo loại ghế!");
            }
            return View(seatType);

        }
        public ActionResult Edit(int id)
        {
            var result = Authenticate();
            if(result==1)
            {
                SeatType seatType = seatTypeService.GetSeatType(id);
                return View(seatType);
            }
            else
            {
                return View("Error404");
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SeatType seatType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    seatTypeService.Update(seatType);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Không thể thay đổi thông tin loại ghế!");
            }
            return View(seatType);
        }

        public ActionResult Delete(int id)
        {
            var result = Authenticate();
            if(result==1)
            {
                SeatType seatType = seatTypeService.GetSeatType(id);
                return View(seatType);
            }
            else
            {
                return View("Error404");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SeatType seatType)
        {
            try
            {
                seatType = seatTypeService.GetSeatType(id);
                seatTypeService.Delete(id);
                return RedirectToAction("Index");

            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể xóa loại ghế");
            }
            return View(seatType);
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