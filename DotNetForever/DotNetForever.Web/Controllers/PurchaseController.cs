using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DotNetForever.Manager.Manager;
using DotNetForever.Model.Model;
using DotNetForever.Web.ViewModels;

namespace DotNetForever.Web.Controllers
{
    public class PurchaseController : Controller
    {
       PurchaseManager _purchaseManager=new PurchaseManager();
       private SupplierManager _supplierManager = new SupplierManager();
       private CategoryManager _categoryManager = new CategoryManager();
       private ProductManager _productManager = new ProductManager();
       private PurchaseDetailsManager _purchaseDetailsManager=new PurchaseDetailsManager();
       SaleManager _saleManager=new SaleManager();

        // GET: Category
        public ActionResult Index(string search)
        {
            PurchaseViewModel model = new PurchaseViewModel();
            if (!String.IsNullOrEmpty(search))
            {
                model.Purchases = _purchaseManager.GetAll().Where(x => (x.Code.ToLower().Contains(search.ToLower()) || x.Supplier.Name.ToLower().Contains(search.ToLower()))).ToList();
            }
            else
            {
                model.Purchases = _purchaseManager.GetAll();
            }

            model.Search = search;
            return View( model);
        }

       
        [HttpGet]
        public ActionResult Create()
        {

            string code = _purchaseManager.GetLastPurchaseCode();


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
            PurchaseDetailsViewModel model = new PurchaseDetailsViewModel
            {
                Suppliers = _supplierManager.GetAll(),
                Categories = _categoryManager.GetAll(),
                //PurchaseDetail = new PurchaseDetail(),
                Code=code
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Purchase purchase)
        {

            JsonResult jason = new JsonResult();

            if (ModelState.IsValid)
            {
                jason.Data = _purchaseManager.Add(purchase)
                    ? new {Success = true, Message = "Saved Successfully"}
                    : new {Success = true, Message = "Unable to Save"};
            }


            return RedirectToAction("Index");
        }

        //from purchase details
        public JsonResult GetPurchaseDetailByProductId(int productId,DateTime purchaseDateTime)
        {
            JsonResult jason = new JsonResult();
            //var products = _productManager.GetProductByCategoryId(productId)
            //    .Select(x => new { Code = x.Id, AvailableQuantity = x });
            var productDetails = _purchaseDetailsManager.GetPurchaseDetailByProductId(productId);
            var product = _productManager.GetById(productId);

            jason.Data = null;
            if (productDetails !=null && product !=null)
            {
                jason.Data = new
                {
                    ProductCode = product.Code,
                    AvailableQty = _purchaseManager.GetPurchaseProductQtyByIdAndDate(productId, purchaseDateTime) - _saleManager.GetSoldProductQtyByIdAndDate(productId, purchaseDateTime),
                    PreviousUnitPrice = productDetails.UnitPrice,
                    PreviousMRP = productDetails.MRP
                };

            }

            //return Json(jason, JsonRequestBehavior.AllowGet);
            return jason;
        }


        public ActionResult PurchaseDetails(int purchaseId)
        {
            PurchaseInfoModalViewModel model=new PurchaseInfoModalViewModel();
            model.PurchaseDetails= _purchaseDetailsManager.GetAllPurchaseDetailByPurchaseId(purchaseId);
            model.Purchase = _purchaseManager.GetAll().FirstOrDefault(x => x.Id == purchaseId);
            model.SubTotal = model.PurchaseDetails.Select(x => x.TotalPrice).DefaultIfEmpty(0).Sum();

            return PartialView("_PurchaseDetails", model);
        }

    }
}