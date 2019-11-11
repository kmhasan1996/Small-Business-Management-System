using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetForever.Manager.Manager;
using DotNetForever.Model.Model;
using DotNetForever.Web.ViewModels;

namespace DotNetForever.Web.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager _customerManager=new CustomerManager();
        // GET: Customer
        public ActionResult Index(string search)
        {
            CustomerListViewModel model = new CustomerListViewModel();
            model.Customers = _customerManager.GetAll();
            if (!String.IsNullOrEmpty(search))
            {
                model.Customers = _customerManager.Search(search);
            }

            model.Search = search;
            return View(model);
        }

        //public ActionResult Listing()
        //{
        //    var product = _productManager.GetAll();

        //    return PartialView("_Listing", product);
        //}

        [HttpGet]
        public ActionResult Create()
        {
           Customer model=new Customer();
            return PartialView("_Create", model);

        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            JsonResult jason = new JsonResult();

            if (_customerManager.Add(customer))
            {
                jason.Data = new { Success = true, Message = "Saved Successfully" };
            }
            else
            {
                jason.Data = new { Success = true, Message = "Unable to save" };
            }

            return jason;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = _customerManager.GetById(id);
            return PartialView("_Edit", customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            JsonResult jason = new JsonResult();
            var existingCustomer = _customerManager.GetById(customer.Id);
            existingCustomer.Code = customer.Code;
            existingCustomer.Name = customer.Name;
            existingCustomer.Address = customer.Address;
            existingCustomer.Email = customer.Email;
            existingCustomer.Contact = customer.Contact;
            existingCustomer.LoyaltyPoint = customer.LoyaltyPoint;
            

            if (_customerManager.Update(existingCustomer))
            {
                jason.Data = new { Success = true };
            }
            else
            {
                jason.Data = new { Success = true, Message = "Unable to update" };
            }

            return jason;
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _customerManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}