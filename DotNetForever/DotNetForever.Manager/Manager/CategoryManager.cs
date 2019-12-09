using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetForever.Model.Model;
using DotNetForever.Repository.Repository;

namespace DotNetForever.Manager.Manager
{
    public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();
        public bool Add(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public bool UniqueName(Category category)
        {
            return _categoryRepository.UniqueName(category);
        }

        public bool Update(Category category)
        {
            return _categoryRepository.Update(category);
        }

        public bool Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public List<Category> Search(string search)
        {
            return _categoryRepository.Search(search);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public int GetCount()
        {
            return _categoryRepository.GetCount();
        }

        public string GetLastCategoryCode()
        {
            return _categoryRepository.GetLastCategoryCode();
        }
    }
}
