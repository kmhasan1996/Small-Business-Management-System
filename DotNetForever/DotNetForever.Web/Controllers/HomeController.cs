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
    public class HomeController : Controller
    {
       
        // GET: Home
        public ActionResult Index()
        {
            ProductManager _productManager = new ProductManager();

            CategoryManager _categoryManager = new CategoryManager();

            CustomerManager _customerManager = new CustomerManager();
            SupplierManager _supplierManager = new SupplierManager();

            SideMenuViewModel model = new SideMenuViewModel();
            model.ProductCount = _productManager.GetCount();
            model.CategoryCount = _categoryManager.GetCount();
            model.CustomerCount = _customerManager.GetCount();
            model.SupplierCount = _supplierManager.GetCount();
           
            return View(model);
        }


	    [HttpGet]
        public ActionResult SideMenu()
        {
            ProductManager _productManager = new ProductManager();

            CategoryManager _categoryManager = new CategoryManager();

            CustomerManager _customerManager=new CustomerManager();
            SupplierManager _supplierManager=new SupplierManager();

            SideMenuViewModel model=new SideMenuViewModel();
            model.ProductCount = _productManager.GetCount();
            model.CategoryCount = _categoryManager.GetCount();
            model.CustomerCount = _customerManager.GetCount();
            model.SupplierCount = _supplierManager.GetCount();
            return PartialView("_SideMenu", model);
        }
    }
}