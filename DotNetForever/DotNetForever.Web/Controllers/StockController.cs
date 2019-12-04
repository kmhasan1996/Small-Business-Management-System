using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DotNetForever.Manager.Manager;
using DotNetForever.Web.Models;
using DotNetForever.Web.ViewModels;

namespace DotNetForever.Web.Controllers
{
    public class StockController : Controller
    {
       
        CategoryManager _categoryManager=new CategoryManager();
        ProductManager _productManager=new ProductManager();
        SharedManager _sharedManager=new SharedManager();

      
        [HttpGet]
        public ActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            var categories = _categoryManager.GetAll();
            
            return View(categories);
        }
        

        public ActionResult Search(int? categoryId,int? productId,  DateTime startDate, DateTime endDate)
        {
            var stocks = _sharedManager.GetStockReport(categoryId,productId,startDate, endDate);
            return PartialView("_Listing",stocks);
        }
    }
}