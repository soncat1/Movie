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
    public class CinemaController : Controller
    {

        private CinemaService cinemaService;
        public CinemaController()
        {
            cinemaService = new CinemaService();
        }
        // GET: Admin/Cinema
        public ActionResult Index()
        {
            return View(cinemaService.GetAll());
        }
        public ActionResult Details(int id)
        {
            Cinema cinema = cinemaService.GetCinema(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
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
            Cinema cinema = cinemaService.GetCinema(id);
            return View(cinema);
        }

        [HttpPost]
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
            Cinema cinema = cinemaService.GetCinema(id);
            return View(cinema);
        }

        [HttpPost]
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
    }
}