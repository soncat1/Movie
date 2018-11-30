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
    public class ShowtimeController : BaseController
    {
        private ShowtimeService showtimeService;
        private FilmService filmService;
        private RoomService roomService;
        List<int> listQueue = new List<int> { 1, 2, 3, 4 };

        public ShowtimeController()
        {
            filmService = new FilmService();
            showtimeService = new ShowtimeService();
            roomService = new RoomService();
        }
        // GET: Admin/Showtime
        public ActionResult Index()
        {
            var result = Authenticate();
            if(result==1)
            {
                return View(showtimeService.GetAll());
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
                Showtime showtime = showtimeService.GetShowtime(id);
                if (showtime == null)
                {
                    return HttpNotFound();
                }
                return View(showtime);
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
                ViewBag.Film = filmService.GetAll();
                ViewBag.Room = roomService.GetAll();
                ViewBag.Queue = listQueue;
                return View();
            }
            else
            {
                return View("Error404");
            }
          
        }

        public JsonResult CheckCreate(DateTime? showDate, int? roomId)

        {       
            ViewBag.Film = filmService.GetAll();
            ViewBag.Room = roomService.GetAll();

            List<int> listQueueFromDb = (from c in showtimeService.GetAll()
                                        where c.RoomId.Equals(roomId) && c.ShowDate.Equals(showDate)
                                        select c.Queue).ToList();

            foreach (var item in listQueueFromDb)
            {
                if (listQueue.Contains(item))
                {
                    listQueue.Remove(item);
                }
            }
            ViewBag.Queue = listQueue;


            return Json(listQueue, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Showtime showtime)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    showtimeService.Add(showtime);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể tạo lịch chiếu!");
            }
            return View(showtime);

        }
        public ActionResult Edit(int id)
        {
            var result = Authenticate();
            if(result==1)
            {
                ViewBag.Queue = listQueue;

                Showtime showtime = showtimeService.GetShowtime(id);
                TempData["Queue"] = showtime.Queue;
                ViewBag.Film = filmService.GetAll();
                ViewBag.Room = roomService.GetAll();
                return View(showtime);
            }
            else
            {
                return View("Error404");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Showtime showtime)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    showtimeService.Update(showtime);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Không thể thay đổi thông tin lịch chiếu!");
            }
            return View(showtime);
        }

        public ActionResult Delete(int id)
        {
            var result = Authenticate();
            if(result==1)
            {
                Showtime showtime = showtimeService.GetShowtime(id);
                return View(showtime);
            }
            else
            {
                return View("Error404");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Showtime showtime)
        {
            try
            {
                showtime = showtimeService.GetShowtime(id);
                showtimeService.Delete(id);
                return RedirectToAction("Index");

            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể xóa lịch chiếu");
            }
            return View(showtime);
        }
        public int Authenticate()
        {
            var employee = (Employee)Session["Employee"];
            if (employee.Department.Name == "Nhân viên quản lý lịch chiếu" || employee.Department.Name == "Tổng giám đốc")
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