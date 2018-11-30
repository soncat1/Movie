using Movie.Models;
using Movie.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Presentation.Areas.Admin.Controllers
{
    public class FilmController : BaseController
    {
        private FilmService filmService;
        private CategoryService categoryService;
        public FilmController()
        {
            filmService = new FilmService();
            categoryService = new CategoryService();
        }
        // GET: Admin/Film
        public ActionResult Index()
        {
            var result = Authenticate();
            if(result==1)
            {
                return View(filmService.GetAll());
            }
            else
            {
                return View("Error404");
            }
        }
        public ActionResult Details(int id)
        {
            var result = Authenticate();
            if (result==1)
            {
                Film film = filmService.GetFilm(id);
                if (film == null)
                {
                    return HttpNotFound();
                }
                return View(film);
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
                ViewBag.Category = categoryService.GetAll();
                return View();
            }
            else
            {
                return View("Error404");
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film,HttpPostedFileBase file)
        {
            var path = "";
            if(file!=null)
            {
                string FileName = Path.GetFileName(Request.Files[0].FileName);
                if(file.ContentLength>0)
                {
                    //for checking uploaded file is image or not
                    if(Path.GetExtension(file.FileName).ToLower()==".jpg"
                        ||Path.GetExtension(file.FileName).ToLower()==".png"
                            ||Path.GetExtension(file.FileName).ToLower()==".gif"
                            ||Path.GetExtension(file.FileName).ToLower()==".jpeg")
                    {
                        path = Path.Combine(Server.MapPath("~/Content/Images"), FileName);
                        file.SaveAs(path);
                        FileName = "/Content/Images/" + FileName;
                        film.Image = FileName;
                    
                    }
                }
            }
            try
            {
                if (ModelState.IsValid)
                {
                    filmService.Add(film);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể tạo phim!");
            }
            return View(film);

        }
        public ActionResult Edit(int id)
        {
            var result = Authenticate();
            if(result==1)
            {
                ViewBag.Category = categoryService.GetAll();
                Film film = filmService.GetFilm(id);
                return View(film);
            }
            else
            {
                return View("Error404");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Film film, HttpPostedFileBase file)
        {
            var path = "";
            if (file != null)
            {
                string FileName = Path.GetFileName(Request.Files[0].FileName);
                if (file.ContentLength > 0)
                {
                    //for checking uploaded file is image or not
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                        || Path.GetExtension(file.FileName).ToLower() == ".png"
                            || Path.GetExtension(file.FileName).ToLower() == ".gif"
                            || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                    {
                        path = Path.Combine(Server.MapPath("~/Content/Images"), FileName);
                        file.SaveAs(path);
                        FileName = "/Content/Images/" + FileName;
                        film.Image = FileName;

                    }
                }
            }
            try
            {
                if (ModelState.IsValid)
                {
                    filmService.Update(film);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Không thể thay đổi thông tin phim!");
            }
            return View(film);
        }

        public ActionResult Delete(int id)
        {
            var result = Authenticate();
            if(result==1)
            {
                Film film = filmService.GetFilm(id);
                return View(film);
            }
            else
            {
                return View("Error404");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Film film)
        {
            try
            {
                film = filmService.GetFilm(id);
                filmService.Delete(id);
                return RedirectToAction("Index");

            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể xóa phim");
            }
            return View(film);
        }
        public int Authenticate()
        {
            var employee = (Employee)Session["Employee"];
            if (employee.Department.Name == "Nhân viên quản lý phim" || employee.Department.Name == "Tổng giám đốc")
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