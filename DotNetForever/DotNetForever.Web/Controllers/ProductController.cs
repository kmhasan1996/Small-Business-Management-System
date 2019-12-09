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
    public class ProductController : Controller
    {
        ProductManager _productManager = new ProductManager();
        CategoryManager _categoryManager = new CategoryManager();

        // GET: Product
        public ActionResult Index(string search)
        {
            ProductListViewModel model=new ProductListViewModel();
            model.Products = _productManager.GetAll();
            if (!String.IsNullOrEmpty(search))
            {
                model.Products = _productManager.Search(search);
            }
           
            model.Search = search;
            return View(model);
        }

       
        public bool UniqueName(Product product)
        {
            return _productManager.UniqueName(product);
        }
       
        public JsonResult GetProductByCategoryId(int categoryId)
        {
            var products = _productManager.GetProductByCategoryId(categoryId)
                .Select(x => new {Id = x.Id, Name = x.Name});

            return Json(products, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProductCodeByProductId(int productId)
        {
            JsonResult jason = new JsonResult();
            var product = _productManager.GetById(productId);

            jason.Data = null;
            if (product != null)
            {
                jason.Data = new
                {
                    ProductCode = product.Code
                };

            }

            return jason;
        }


        [HttpGet]
        public ActionResult Create()
        {

            string code = _productManager.GetLastProductCode();


            if (code == null)
            {
                code = "0001";
            }
            else
            {
                int number = int.Parse(code);
                code = (++number).ToString("D" + code.Length);

            }


            //dynamic model = new System.Dynamic.ExpandoObject();

            //model.code = code;

            CreateProductViewModel model = new CreateProductViewModel();
            model.Categories = _categoryManager.GetAll();
            model.Product=new Product();
            model.Product.Code = code;
            return PartialView("_Create", model);

        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            JsonResult jason = new JsonResult();

            if (ModelState.IsValid)
            {
                jason.Data = _productManager.Add(product) ? new { Success = true, Message = "Saved Successfully" } : new { Success = false, Message = "Unable to Save" };
            }

            return jason;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _productManager.GetById(id);
            return PartialView("_Edit",product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            JsonResult jason = new JsonResult();
            var existingProduct = _productManager.GetById(product.Id);
            existingProduct.Code = product.Code;
            existingProduct.Name = product.Name;
            existingProduct.ReorderLevel = product.ReorderLevel;
            existingProduct.Description = product.Description;

            if (ModelState.IsValid)
            {
                jason.Data = _productManager.Update(existingProduct)
                    ? (object) new {Success = true, Message = "Updated Successfully" }
                    : new {Success = true, Message = "Unable to Update"};
            }
            

            return jason;
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _productManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}