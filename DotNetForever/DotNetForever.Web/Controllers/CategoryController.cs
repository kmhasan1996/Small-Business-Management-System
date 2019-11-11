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
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
        // GET: Category
        public ActionResult Index(string search)
        {
            CategoryListViewModel model=new CategoryListViewModel();
            model.Categories = _categoryManager.GetAll();
            if (!String.IsNullOrEmpty(search))
            {
                model.Categories = _categoryManager.Search(search);
            }

            model.Search = search;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Category model=new Category();

            return PartialView("_Create", model);

        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            JsonResult jason = new JsonResult();

            if (_categoryManager.Add(category))
            {
                jason.Data = new { Success = true, Message = "Saved Successfully" };
            }
            else
            {
                jason.Data = new { Success = true, Message = "Unable to save" };
            }

            return jason;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = _categoryManager.GetById(id);
            return PartialView("_Edit", category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            JsonResult jason = new JsonResult();
            var existingCategory = _categoryManager.GetById(category.Id);
            existingCategory.Code = category.Code;
            existingCategory.Name = category.Name;
            

            if (_categoryManager.Update(existingCategory))
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
            _categoryManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}