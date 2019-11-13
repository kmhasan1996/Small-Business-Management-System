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

        //public ActionResult Listing()
        //{
        //    var product = _productManager.GetAll();

        //    return PartialView("_Listing", product);
        //}

        [HttpGet]
        public ActionResult Create()
        {
            CreateProductViewModel model = new CreateProductViewModel();
            model.Categories = _categoryManager.GetAll();
            model.Product=new Product();
            return PartialView("_Create", model);

        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            JsonResult jason = new JsonResult();

            if (ModelState.IsValid)
            {
                if (_productManager.Add(product))
                {
                    jason.Data = new { Success = true, Message = "Saved Successfully" };
                }
                else
                {
                    jason.Data = new { Success = true, Message = "Unable to save" };
                }
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
            existingProduct.RecorderLevel = product.RecorderLevel;
            existingProduct.Description = product.Description;

            if (_productManager.Update(existingProduct))
            {
                jason.Data = new { Success = true };
            }
            else
            {
                jason.Data = new { Success = true, Message = "Unable to update" };
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