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
    public class DepartmentController : Controller
    {
        private DepartmentService departmentService;
        private CinemaService cinemaService;
        public DepartmentController()
        {
            departmentService = new DepartmentService();
            cinemaService = new CinemaService();
        }
        // GET: Admin/Department
        public ActionResult Index()
        {
            return View(departmentService.GetAll());
        }
        public ActionResult Details(int id)
        {
            Department department = departmentService.GetDepartment(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        public ActionResult Create()
        {
            ViewBag.Cinema = cinemaService.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    departmentService.Add(department);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể tạo chức vụ!");
            }
            return View(department);

        }
        public ActionResult Edit(int id)
        {
            ViewBag.Cinema = cinemaService.GetAll();
            Department department = departmentService.GetDepartment(id);
            return View(department);
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    departmentService.Update(department);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Không thể thay đổi thông tin chức vụ!");
            }
            return View(department);
        }

        public ActionResult Delete(int id)
        {
            Department department = departmentService.GetDepartment(id);
            return View(department);
        }

        [HttpPost]
        public ActionResult Delete(int id, Department department)
        {
            try
            {
                department = departmentService.GetDepartment(id);
                departmentService.Delete(id);
                return RedirectToAction("Index");

            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể xóa chức vụ");
            }
            return View(department);
        }
    }
}