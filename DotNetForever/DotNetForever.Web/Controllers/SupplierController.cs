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
    public class SupplierController : Controller
    {
        SupplierManager _supplierManager=new SupplierManager();
        // GET: Supplier
        public ActionResult Index(string search)
        {
            SupplierListViewModel model = new SupplierListViewModel();
            model.Suppliers = _supplierManager.GetAll();
            if (!String.IsNullOrEmpty(search))
            {
                model.Suppliers = _supplierManager.Search(search);
            }

            model.Search = search;
            return View(model);
        }
        public bool UniqueEmail(Supplier supplier)
        {
            return _supplierManager.UniqueEmail(supplier);
        }
        public bool UniqueContact(Supplier supplier)
        {
            return _supplierManager.UniqueContact(supplier);
        }

        public ActionResult SupplierDetails(int id)
        {
            var supplier = _supplierManager.GetById(id);

            return PartialView("_SupplierDetails", supplier);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //Supplier model = new Supplier();

            string code = _supplierManager.GetLastSupplierCode();

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
        public ActionResult Create(Supplier supplier)
        {
            JsonResult jason = new JsonResult();

            if (ModelState.IsValid)
            {
                jason.Data = _supplierManager.Add(supplier) ? new { Success = true, Message = "Saved Successfully" } : new { Success = true, Message = "Unable to save" };
            }
           

            return jason;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var supplier = _supplierManager.GetById(id);
            return PartialView("_Edit", supplier);
        }

        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            JsonResult jason = new JsonResult();
            var existingSupplier = _supplierManager.GetById(supplier.Id);
            existingSupplier.Code = supplier.Code;
            existingSupplier.Name = supplier.Name;
            existingSupplier.Address = supplier.Address;
            existingSupplier.Email = supplier.Email;
            existingSupplier.Contact = supplier.Contact;
            existingSupplier.ContactPerson = supplier.ContactPerson;

            if (ModelState.IsValid)
            {
                jason.Data = _supplierManager.Update(existingSupplier) ? new { Success = true, Message = "Updated Successfully" } : new { Success = true, Message = "Unable to update" };
            }
           

            return jason;
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _supplierManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}