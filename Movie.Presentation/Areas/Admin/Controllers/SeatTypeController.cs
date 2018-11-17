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
    public class SeatTypeController : Controller
    {
        private SeatTypeService seatTypeService;
        public SeatTypeController()
        {
            seatTypeService = new SeatTypeService();
        }
        // GET: Admin/SeatType
        public ActionResult Index()
        {
            return View(seatTypeService.GetAll());
        }
        public ActionResult Details(int id)
        {
            SeatType seatType = seatTypeService.GetSeatType(id);
            if (seatType == null)
            {
                return HttpNotFound();
            }
            return View(seatType);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
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
            SeatType seatType = seatTypeService.GetSeatType(id);
            return View(seatType);
        }

        [HttpPost]
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
            SeatType seatType = seatTypeService.GetSeatType(id);
            return View(seatType);
        }

        [HttpPost]
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
    }
}