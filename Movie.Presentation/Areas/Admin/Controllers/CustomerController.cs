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
    public class CustomerController : Controller
    {
        private CustomerService customerService;
        public CustomerController()
        {
            customerService = new CustomerService();
        }
        // GET: Admin/Customer
        public ActionResult Index()
        {
            return View(customerService.GetAll());
        }
        public ActionResult Details(int id)
        {
            Customer customer = customerService.GetCustomer(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
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
            Customer customer = customerService.GetCustomer(id);
            return View(customer);
        }

        [HttpPost]
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
            Customer customer = customerService.GetCustomer(id);
            return View(customer);
        }

        [HttpPost]
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
    }
}