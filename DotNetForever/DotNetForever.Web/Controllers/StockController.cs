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

      
        public ActionResult Index(/*DateTime startDate, DateTime endDate*/)
        {
            DateTime startDate = new DateTime(2019, 11, 22, 0, 0, 0);
            DateTime endDate = new DateTime(2019, 11, 30, 0, 0, 0);


            StockViewModel model = new StockViewModel
            {
                Categories = _categoryManager.GetAll(),
                Stocks = _sharedManager.GetStockReport(startDate, endDate)
                //Stocks = null
            };
            return View(model);
        }

        
        public ActionResult Search(DateTime startDate, DateTime endDate)
        {
            //DateTime startDate = new DateTime(2019, 11, 14, 0, 0, 0);
            //DateTime endDate = new DateTime(2019, 11, 24, 0, 0, 0);


            //StockViewModel model = new StockViewModel
            //{
            //    Categories = _categoryManager.GetAll(),
            //    Stocks = _sharedManager.GetStockReport(startDate, endDate)
            //};

            List<Stock> stocks=new List<Stock>();
            stocks = _sharedManager.GetStockReport(startDate, endDate);
            return PartialView("_Listing",stocks);
        }
    }
}