using Movie.Presentation.Areas.Admin.Models;
using Movie.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Presentation.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private EmployeeService employeeService;
        //public static int currentSession;
        public LoginController()
        {
            employeeService = new EmployeeService();
        }
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = employeeService.Login(model.UserName, model.Password);
                if (result == 1)
                {
                   
                        var employee = employeeService.GetEmployeeLogin(model.UserName);
                        Session["Employee"] = employee;
                        //currentSession = (int)Session["EmployeeId"];
                        return RedirectToAction("Index", "Category");
                    
                }
                else 
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Logout()
        {

            Session.Remove("Employee");
            return RedirectToAction("Index", "Login");
        }
    }
}