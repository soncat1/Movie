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
    public class EmployeeController : Controller
    {
        
        private EmployeeService employeeService;
        private DepartmentService departmentService;
        public EmployeeController()
        {
            employeeService = new EmployeeService();
            departmentService = new DepartmentService();
        }
        // GET: Admin/Employee
        public ActionResult Index()
        {
            return View(employeeService.GetAll());
        }
        public ActionResult Details(int id)
        {
            Employee employee = employeeService.GetEmployee(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        public ActionResult Create()
        {
            ViewBag.Department = departmentService.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeService.Add(employee);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể tạo nhân viên!");
            }
            return View(employee);

        }
        public ActionResult Edit(int id)
        {
            ViewBag.Department = departmentService.GetAll();
            Employee employee = employeeService.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeService.Update(employee);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Không thể thay đổi thông tin nhân viên!");
            }
            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            Employee employee = employeeService.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                employee = employeeService.GetEmployee(id);
                employeeService.Delete(id);
                return RedirectToAction("Index");

            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể xóa nhân viên");
            }
            return View(employee);
        }
    }
}