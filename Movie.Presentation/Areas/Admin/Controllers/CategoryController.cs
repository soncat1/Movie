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
    public class CategoryController : Controller
    {

        private CategoryService categoryService;
        public CategoryController()
        {
            categoryService = new CategoryService();
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(categoryService.GetAll());
        }
        public ActionResult Details(int id)
        {
            Category category = categoryService.GetCategory(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
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
            Category category = categoryService.GetCategory(id);
            return View(category);
        }

        [HttpPost]
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
            Category category = categoryService.GetCategory(id);
            return View(category);
        }

        [HttpPost]
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
    }
}