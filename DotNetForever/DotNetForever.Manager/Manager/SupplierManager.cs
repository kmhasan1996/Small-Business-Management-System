using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetForever.Model.Model;
using DotNetForever.Repository.Repository;

namespace DotNetForever.Manager.Manager
{
    public class SupplierManager
    {
        readonly SupplierRepository _supplierRepository = new SupplierRepository();
        public bool Add(Supplier supplier)
        {
            return _supplierRepository.Add(supplier);
        }

        public bool Update(Supplier supplier)
        {
            return _supplierRepository.Update(supplier);
        }

        public bool Delete(int id)
        {
            return _supplierRepository.Delete(id);
        }
        public Supplier GetById(int id)
        {
            return _supplierRepository.GetById(id);
        }

        public List<Supplier> Search(string search)
        {
            return _supplierRepository.Search(search);
        }
        public List<Supplier> GetAll()
        {
            return _supplierRepository.GetAll();
        }

        public int GetCount()
        {
            return _supplierRepository.GetCount();
        }
    }
}
