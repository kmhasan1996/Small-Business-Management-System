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

        public ActionResult CustomerDetails(int id)
        {
            var customer = _customerManager.GetById(id);

            return PartialView("_CustomerDetails", customer);
        }

        public bool UniqueEmail(Customer customer)
        {
            return _customerManager.UniqueEmail(customer);
        }
        public bool UniqueContact(Customer customer)
        {
            return _customerManager.UniqueContact(customer);
        }

        [HttpGet]
        public ActionResult Create()
        {


            string code = _customerManager.GetLastCustomerCode();

            if (code == null)
            {
                code = "0001";
            }
            else
            {
                int number = int.Parse(code);
                code = (++number).ToString("D" + code.Length);

            }
            dynamic model = new System.Dynamic.ExpandoObject();
            model.Code = code;
            return PartialView("_Create", model);

        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            JsonResult jason = new JsonResult();

            if (ModelState.IsValid)
            {
                jason.Data = _customerManager.Add(customer) ? new { Success = true, Message = "Saved Successfully" } : new { Success = true, Message = "Unable to Save" };
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

            if (ModelState.IsValid)
            {
                jason.Data = _customerManager.Update(existingCustomer) ? new { Success = true, Message = "Updated Successfully" } : new { Success = true, Message = "Unable to Update" };
            }
            
            return jason;
        }


        public ActionResult UpdateLoyaltyPoint(int customerId,int loyaltyPoint)
        {
            JsonResult jason = new JsonResult();
            var existingCustomer = _customerManager.GetById(customerId);
            //existingCustomer.Code = customer.Code;
            //existingCustomer.Name = customer.Name;
            //existingCustomer.Address = customer.Address;
            //existingCustomer.Email = customer.Email;
            //existingCustomer.Contact = customer.Contact;
            existingCustomer.LoyaltyPoint = loyaltyPoint;

            if (ModelState.IsValid)
            {
                jason.Data = _customerManager.Update(existingCustomer) ? new { Success = true, Message = "Updated Successfully" } : new { Success = true, Message = "Unable to Update" };
            }

            return jason;
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _customerManager.Delete(id);
            return RedirectToAction("Index");
        }

        public JsonResult GetLoyaltyPointById(int customerId)
        {
            JsonResult jason = new JsonResult();

            jason.Data = new
            {
                loyaltyPoint=_customerManager.GetLoyaltyPointById(customerId)
            };
            return jason;
        }

    }
}