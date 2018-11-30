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
    public class EmployeeController : BaseController
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
            var result = Authenticate();
            if(result==1)
            {
                return View(employeeService.GetAll());
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
                Employee employee = employeeService.GetEmployee(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
            else
            {
                return View("Error404");
            }
            
        }
        public ActionResult Create()
        {
            var result = Authenticate();
            if (result==1)
            {
                ViewBag.Department = departmentService.GetAll();
                return View();
            }
            else
            {
                return View("Error404");
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            var result = Authenticate();
            if(result==1)
            {
                ViewBag.Department = departmentService.GetAll();
                Employee employee = employeeService.GetEmployee(id);
                return View(employee);
            }
            else
            {
                return View("Error404");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            var result = Authenticate();
            if (result==1)
            {
                Employee employee = employeeService.GetEmployee(id);
                return View(employee);
            }
            else
            {
                return View("Error404");
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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