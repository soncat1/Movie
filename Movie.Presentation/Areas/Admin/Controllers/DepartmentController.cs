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
    public class DepartmentController : BaseController
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
            var result = Authenticate();
            if (result == 1)
            {
                return View(departmentService.GetAll());
            }
            else
                return View("Error404");
        }
        public ActionResult Details(int id)
        {
            var result = Authenticate();
            if (result == 1)
            {
                Department department = departmentService.GetDepartment(id);
                if (department == null)
                {
                    return HttpNotFound();
                }
                return View(department);
            }
            else
                return View("Error404");
          
        }
        public ActionResult Create()
        {
            var result = Authenticate();
            if (result == 1)
            {
                ViewBag.Cinema = cinemaService.GetAll();
                return View();
            }
            else
                return View("Error404");
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            var result = Authenticate();
            if (result == 1)
            {
                ViewBag.Cinema = cinemaService.GetAll();
                Department department = departmentService.GetDepartment(id);
                return View(department);
            }
            else
                return View("Error404");
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            var result = Authenticate();
            if (result == 1)
            {
                Department department = departmentService.GetDepartment(id);
                return View(department);
            }
            else
                return View("Error404");
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public int Authenticate()
        {
            var employee = (Employee)Session["Employee"];
            if (employee.Department.Name == "Nhân viên quản lý phòng ban" || employee.Department.Name == "Tổng giám đốc")
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