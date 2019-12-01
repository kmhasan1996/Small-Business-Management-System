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
        private SaleDetailsManager _saleDetailsManager=new SaleDetailsManager();
        public ActionResult Index(string search)
        {
            SaleViewModel model = new SaleViewModel {Sales = _saleManager.GetAll(), Search = search};
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            string code = _saleManager.GetLastSaleCode();


            string year = DateTime.Parse(DateTime.Now.ToString()).Year.ToString();
            if (code == null)
            {
                code = year + "-0001";
            }
            else
            {
                string[] afterSplit = code.Split('-');

                string serialNo = afterSplit[afterSplit.Length - 1];
                int number = int.Parse(serialNo);
                code = year + "-" + (++number).ToString("D" + serialNo.Length);
            }


            SaleDetailViewModel model = new SaleDetailViewModel
            {
                Customers = _customerManager.GetAll(),
                Categories = _categoryManager.GetAll(),
                Products = _productManager.GetAll(),
                SaleDetail = new SaleDetail(),
                Code = code
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Sale sale)
        {

            JsonResult jason = new JsonResult();

            if (ModelState.IsValid)
            {
                jason.Data = _saleManager.Add(sale)
                    ? new { Success = true, Message = "Saved Successfully" }
                    : new { Success = true, Message = "Unable to Save" };
            }


            return RedirectToAction("Index");
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
        public ActionResult SaleDetails(int saleId)
        {
            List<SaleDetail> saleDetails = _saleDetailsManager.GetAllSaleDetailBySaleId(saleId);

            return PartialView("_SaleDetails", saleDetails);
        }

    }
}