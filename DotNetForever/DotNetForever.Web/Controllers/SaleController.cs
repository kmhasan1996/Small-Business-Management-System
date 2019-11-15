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
    public class SaleController : Controller
    {
        SaleManager _saleManager=new SaleManager();
       CustomerManager _customerManager=new CustomerManager();
        private CategoryManager _categoryManager = new CategoryManager();
        private ProductManager _productManager = new ProductManager();

        public ActionResult Index(string search)
        {
            SaleViewModel model = new SaleViewModel {Sales = _saleManager.GetAll(), Search = search};
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SaleDetailViewModel model = new SaleDetailViewModel
            {
                Customers = _customerManager.GetAll(),
                Categories = _categoryManager.GetAll(),
                Products = _productManager.GetAll(),
                SaleDetail = new SaleDetail()
            };
            return View(model);
        }

    }
}