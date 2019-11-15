using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetForever.Manager.Manager;
using DotNetForever.Web.ViewModels;

namespace DotNetForever.Web.Controllers
{
    public class StockController : Controller
    {
       
       CategoryManager _categoryManager=new CategoryManager();
        ProductManager _productManager=new ProductManager();

        public ActionResult Index()
        {
            StockViewModel model = new StockViewModel
            {
                Categories = _categoryManager.GetAll(),
                Products = _productManager.GetAll(),
                Stocks = null
            };
            return View(model);
        }
    }
}