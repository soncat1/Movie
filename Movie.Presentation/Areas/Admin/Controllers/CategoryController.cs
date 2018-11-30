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
    public class CategoryController : BaseController
    {

        private CategoryService categoryService;
        private EmployeeService employeeService;
        public CategoryController()
        {

            categoryService = new CategoryService();
            employeeService = new EmployeeService();
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            var result = Authenticate();
            if (result == 1)
                return View(categoryService.GetAll());
            else
                return View("Error404");
        }
        public ActionResult Details(int id)
        {
            var result = Authenticate();
            if (result == 1)
            {
                Category category = categoryService.GetCategory(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
            else
                return View("Error404");

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
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoryService.Add(category);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể tạo danh mục!");
            }
            return View(category);

        }
        public ActionResult Edit(int id)
        {
            var result = Authenticate();
            if (result == 1)
            {
                Category category = categoryService.GetCategory(id);
                return View(category);
            }
            else
            {
                return View("Error404");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoryService.Update(category);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Không thể thay đổi thông tin danh mục!");
            }
            return View(category);
        }

        public ActionResult Delete(int id)
        {
            var result = Authenticate();
            if (result == 1)
            {
                Category category = categoryService.GetCategory(id);
                return View(category);
            }
            else
            {
                return View("Error404");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                category = categoryService.GetCategory(id);
                categoryService.Delete(id);
                return RedirectToAction("Index");

            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể xóa danh mục");
            }
            return View(category);
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