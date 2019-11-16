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

            if (ModelState.IsValid)
            {
                jason.Data = _categoryManager.Add(category) ? new { Success = true, Message = "Saved Successfully" } : new { Success = true, Message = "Unable to Save" };
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

            if (ModelState.IsValid)
            {
                jason.Data = _categoryManager.Update(existingCategory) ? new {Success = true, Message = "Updated Successfully" } : new {Success = true, Message = "Unable to Update"};
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