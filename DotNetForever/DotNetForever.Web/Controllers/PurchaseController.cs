using System.Collections.Generic;
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

        // GET: Category
        public ActionResult Index(string search)
        {
            PurchaseViewModel model = new PurchaseViewModel {Purchases = _purchaseManager.GetAll(), Search = search};
            return View( model);
        }

       
        [HttpGet]
        public ActionResult Create()
        {
            PurchaseDetailsViewModel model = new PurchaseDetailsViewModel
            {
                Suppliers = _supplierManager.GetAll(),
                Categories = _categoryManager.GetAll(),
                PurchaseDetail = new PurchaseDetail()
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
        public JsonResult GetPurchaseDetailByProductId(int productId)
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
                    AvailableQty = productDetails.Quantity,
                    PreviousUnitPrice = productDetails.UnitPrice,
                    PreviousMRP = productDetails.MRP
                };

            }

            //return Json(jason, JsonRequestBehavior.AllowGet);
            return jason;
        }


        public ActionResult PurchaseDetails(int purchaseId)
        {
            List<PurchaseDetail> purchaseDetail = _purchaseDetailsManager.GetAllPurchaseDetailByPurchaseId(purchaseId);

            return PartialView("_PurchaseDetails", purchaseDetail);
        }

    }
}