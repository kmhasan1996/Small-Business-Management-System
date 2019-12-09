using System;
using System.Collections.Generic;
using System.Linq;
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
            


            return PartialView("_Listing",stocks);
        }
    }
}