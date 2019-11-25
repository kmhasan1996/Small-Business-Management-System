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
        public ActionResult Index()
        {
            StockViewModel model = new StockViewModel();

            DateTime startDate = DateTime.Today.Date;
            DateTime endDate = DateTime.Today.Date;

            model.Categories = _categoryManager.GetAll();
            model.Stocks = _sharedManager.GetStockReport(null,null,startDate, endDate);
            model.StartDate = startDate;
            model.EndDate = endDate;
           
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string startDate, DateTime endDate)
        {
            StockViewModel model = new StockViewModel();

            //model.Categories = _categoryManager.GetAll();
            //model.Stocks = _sharedManager.GetStockReport(startDate, endDate);
            //model.StartDate = startDate.Date;
            //model.EndDate = endDate.Date;
            return View(model);
        }

        
        public ActionResult Search(int? categoryId,int? productId,  DateTime startDate, DateTime endDate)
        {
            //DateTime startDate = new DateTime(2019, 11, 14, 0, 0, 0);
            //DateTime endDate = new DateTime(2019, 11, 24, 0, 0, 0);


            //StockViewModel model = new StockViewModel
            //{
            //    Categories = _categoryManager.GetAll(),
            //    Stocks = _sharedManager.GetStockReport(startDate, endDate)
            //};

            List<Stock> stocks=new List<Stock>();
            stocks = _sharedManager.GetStockReport(categoryId,productId,startDate, endDate);
            return PartialView("_Listing",stocks);
        }
    }
}