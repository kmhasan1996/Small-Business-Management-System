using DotNetForever.Model.Model;
using System.Collections.Generic;
using DotNetForever.Repository.Repository;

namespace DotNetForever.Manager.Manager
{
    public class ProductManager
    {
        readonly ProductRepository _productRepository = new ProductRepository();


        public bool UniqueName(Product product)
        {
            return _productRepository.UniqueName(product);
        }

        public bool Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public bool Update(Product product)
        {
            return _productRepository.Update(product);
        }

        public bool Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public List<Product> Search(string search)
        {
            return _productRepository.Search(search);
        }

        public int GetCount()
        {
            return _productRepository.GetCount();
        }

        public string GetLastProductCode()
        {
            return _productRepository.GetLastProductCode();
        }

        public List<Product> GetProductByCategoryId(int categoryId)
        {
            return _productRepository.GetProductByCategoryId(categoryId);
        }
    }
}
