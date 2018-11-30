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
    public class CinemaController : BaseController
    {

        private CinemaService cinemaService;
        public CinemaController()
        {
            cinemaService = new CinemaService();
        }
        // GET: Admin/Cinema
        public ActionResult Index()
        {
            var result = Authenticate();
            if (result==1)
            {
                return View(cinemaService.GetAll());
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
                Cinema cinema = cinemaService.GetCinema(id);
                if (cinema == null)
                {
                    return HttpNotFound();
                }
                return View(cinema);
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
            return View("Error404");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cinema cinema)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cinemaService.Add(cinema);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể tạo rạp chiếu!");
            }
            return View(cinema);

        }
        public ActionResult Edit(int id)
        {
            var result = Authenticate();
            if(result==1)
            {
                Cinema cinema = cinemaService.GetCinema(id);
                return View(cinema);
            }
            else
            {
                return View("Error404");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cinema cinema)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cinemaService.Update(cinema);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Không thể thay đổi thông tin rạp chiếu!");
            }
            return View(cinema);
        }

        public ActionResult Delete(int id)
        {
            var result = Authenticate();
            if (result==1)
            {
                Cinema cinema = cinemaService.GetCinema(id);
                return View(cinema);
            }
            else
            {
                return View("Error404");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cinema cinema)
        {
            try
            {
                cinema = cinemaService.GetCinema(id);
                cinemaService.Delete(id);
                return RedirectToAction("Index");

            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể xóa rạp chiếu");
            }
            return View(cinema);
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
    }
}