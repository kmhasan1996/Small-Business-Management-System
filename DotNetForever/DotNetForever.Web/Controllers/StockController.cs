﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DotNetForever.Manager.Manager;
using Rotativa;


namespace DotNetForever.Model.Controllers
{
    public class StockController : Controller
    {
       
        CategoryManager _categoryManager=new CategoryManager();
        SharedManager _sharedManager=new SharedManager();


        //public ActionResult PrintViewToPdf()
        //{
        //    var report = new ActionAsPdf("Search");
        //    return report;
        //}

        [HttpGet]
        public ActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            var categories = _categoryManager.GetAll();
            
            return View(categories);
        }
        

        public ActionResult Search(bool inProduct,bool outProduct,int? categoryId,int? productId,  DateTime startDate, DateTime endDate)
        {
            var stocks = _sharedManager.GetStockReport(categoryId, productId, startDate, endDate);

            if (inProduct && outProduct)
            {
                stocks = stocks.Where(x => x.In != 0 && x.Out != 0).ToList();
            }
            else if (inProduct)
            {
                stocks =  stocks.Where(x => x.In != 0).ToList();
            }
            else if(outProduct)
            {
                stocks = stocks.Where(x => x.Out != 0).ToList();
            }
            else
            {
                stocks = stocks.Where(x => x.OpeningBalance != 0 || x.In != 0 || x.Out != 0 || x.ClosingBalance != 0).ToList();
            }

            if (stocks.Count==0)
            {
                stocks = null;
            }

            return PartialView("_Listing",stocks);
        }
    }
}