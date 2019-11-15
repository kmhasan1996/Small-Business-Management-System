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
    public class PurchaseController : Controller
    {
       PurchaseManager _purchaseManager=new PurchaseManager();
       private SupplierManager _supplierManager = new SupplierManager();
       private CategoryManager _categoryManager = new CategoryManager();
       private ProductManager _productManager = new ProductManager();

        // GET: Category
        public ActionResult Index(string search)
        {
            PurchaseViewModel model = new PurchaseViewModel {Purchases = _purchaseManager.GetAll(), Search = search};
            return View( model);
        }

       
        [HttpGet]
        public ActionResult Create()
        {
            PurchaseDetailsViewModel model = new PurchaseDetailsViewModel
            {
                Suppliers = _supplierManager.GetAll(),
                Categories = _categoryManager.GetAll(),
                Products = _productManager.GetAll(),
                PurchaseDetail = new PurchaseDetail()
            };
            return View(model);
        }


    }
}