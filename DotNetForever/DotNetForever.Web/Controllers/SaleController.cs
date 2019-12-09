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
            SaleViewModel model = new SaleViewModel();


            if (!String.IsNullOrEmpty(search))
            {
                model.Sales = _saleManager.GetAll().Where(x => (x.Code.ToLower().Contains(search.ToLower()) || x.Customer.Name.ToLower().Contains(search.ToLower()))).ToList();
            }
            else
            {
                model.Sales = _saleManager.GetAll();
            }

            model.Search = search;
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

            jason.Data = null;
            if (productDetails !=null)
            {
                jason.Data = new
                {
                    availableProduct = _purchaseManager.GetPurchaseProductQtyByIdAndDate(productId, saleDateTime) - _saleManager.GetSoldProductQtyByIdAndDate(productId, saleDateTime),
                    currentMRP = productDetails.MRP,
                    reorderLevel = productDetails.Product.ReorderLevel
                };
            }
            
            return jason;
        }
        public ActionResult SaleDetails(int saleId)
        {

            SaleInfoModalViewModel model = new SaleInfoModalViewModel();
            model.SaleDetails = _saleDetailsManager.GetAllSaleDetailBySaleId(saleId);
            model.Sale = _saleManager.GetAll().FirstOrDefault(x => x.Id == saleId);
            model.SubTotal = model.SaleDetails.Select(x => x.TotalPrice).DefaultIfEmpty(0).Sum();
            model.DiscountPercentage =
                _saleManager.GetAll().Where(x => x.Id == saleId).Select(x => x.DiscountPercentage).FirstOrDefault();
            model.DiscountAmount = model.SubTotal * model.DiscountPercentage/100;
            model.PayaableAmount = model.SubTotal - model.DiscountAmount;
            return PartialView("_SaleDetails", model);
        }

    }
}