using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetForever.DatabaseContext.DatabaseContext;
using DotNetForever.Model.Model;

namespace DotNetForever.Repository.Repository
{
    public class CategoryRepository
    {
        public bool Add(Category category)
        {
            using (var context = new SMSDbContext())
            {
                context.Categories.Add(category);
                return context.SaveChanges() > 0;
            }
        }
        public bool UniqueName(Category category)
        {
            using (var context = new SMSDbContext())
            {
                var categories=(dynamic)null;
                if (category.Id != 0)
                {
                    categories = context.Categories.Where(x => x.Name.Equals(category.Name) && x.Id != category.Id).ToList();
                }
                else
                {
                    categories = context.Categories.Where(x => x.Name.Equals(category.Name)).ToList();
                }
                

                return categories.Count > 0;
            }
        }
        public bool Update(Category category)
        {
            using (var context = new SMSDbContext())
            {

                Category model = new Category();
                model = context.Categories.Find(category.Id);
                if (model != null)
                {
                    model.Id = category.Id;

                    model.Code = category.Code;
                    model.Name = category.Name;

                }

                return context.SaveChanges() > 0;
                
            }
        }

        public bool Delete(int id)
        {
            using (var context = new SMSDbContext())
            {

                Category category = context.Categories.Find(id);
                context.Categories.Remove(category);
                return context.SaveChanges() > 0;
            }
        }

        public Category GetById(int id)
        {
            using (var context = new SMSDbContext())
            {
                return context.Categories.Find(id);
            }
        }
        public List<Category> GetAll()
        {
            using (var context = new SMSDbContext())
            {
                return context.Categories.Include(x=>x.Products).ToList();

            }
        }
        public List<Category> Search(string search)
        {
            using (var context = new SMSDbContext())
            {
                return context.Categories.Where(x => (x.Name.ToLower().Contains(search.ToLower()) || x.Code.Contains(search) )).ToList();


            }
        }
        public int GetCount()
        {
            using (var context = new SMSDbContext())
            {
                return context.Categories.Count();
            }
        }

        public string GetLastCategoryCode()
        {
            using (var context = new SMSDbContext())
            {
                return context.Categories.OrderByDescending(x => x.Id).Select(x => x.Code).FirstOrDefault();

            }


        }
    }
}
