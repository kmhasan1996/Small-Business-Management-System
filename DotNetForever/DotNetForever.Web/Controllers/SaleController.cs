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
        private SaleManager _saleManager =new SaleManager();
        private CustomerManager _customerManager =new CustomerManager();
        private CategoryManager _categoryManager = new CategoryManager();
        private ProductManager _productManager = new ProductManager();
        private PurchaseManager _purchaseManager=new PurchaseManager();
        private PurchaseDetailsManager _purchaseDetailsManager = new PurchaseDetailsManager();

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

        public JsonResult GetAvailableProductQtyByIdAndDate(DateTime saleDateTime, int productId)
        {
            JsonResult jason = new JsonResult();
            var productDetails= _purchaseDetailsManager.GetPurchaseDetailByProductId(productId);

            jason.Data = new
            {
                availableProduct = _purchaseManager.GetPurchaseProductQtyByIdAndDate(productId,saleDateTime) - _saleManager.GetSoldProductQtyByIdAndDate(productId,saleDateTime),
                currentMRP=productDetails.MRP,
                reorderLevel=productDetails.Product.ReorderLevel
            };
            return jason;
        }

    }
}