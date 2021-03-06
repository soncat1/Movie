﻿using Movie.Models;
using Movie.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Presentation.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        private CustomerService customerService;
        public CustomerController()
        {
            customerService = new CustomerService();
        }
        // GET: Admin/Customer
        public ActionResult Index()
        {
            var result = Authenticate();
            if (result == 1)
                return View(customerService.GetAll());
            else
                return View("Error404");
        }
        public ActionResult Details(int id)
        {
            var result = Authenticate();
            if (result == 1)
            {
                Customer customer = customerService.GetCustomer(id);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                return View(customer);
            }
            else
                return View("Error404");
           
        }
        public ActionResult Create()
        {
            var result = Authenticate();
            if (result == 1)
                return View();
            else
                return View("Error404");
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customerService.Add(customer);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể tạo khách hàng!");
            }
            return View(customer);

        }
        public ActionResult Edit(int id)
        {
            var result = Authenticate();
            if (result == 1)
            {
                Customer customer = customerService.GetCustomer(id);
                return View(customer);
            } 
            else
                return View("Error404");
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customerService.Update(customer);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Không thể thay đổi thông tin khách hàng!");
            }
            return View(customer);
        }

        public ActionResult Delete(int id)
        {
            var result = Authenticate();
            if (result == 1)
            {
                Customer customer = customerService.GetCustomer(id);
                return View(customer);
            }
            else
                return View("Error404");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                customer = customerService.GetCustomer(id);
                customerService.Delete(id);
                return RedirectToAction("Index");

            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể xóa khách hàng");
            }
            return View(customer);
        }
        public int Authenticate()
        {
            var employee = (Employee)Session["Employee"];
            if (employee.Department.Name == "Nhân viên quản lý khách hàng" || employee.Department.Name == "Tổng giám đốc")
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