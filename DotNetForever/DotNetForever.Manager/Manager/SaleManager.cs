using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetForever.Model.Model;
using DotNetForever.Repository.Repository;

namespace DotNetForever.Manager.Manager
{
    public class SaleManager
    {
       SaleRepository _saleRepository=new SaleRepository();

       public bool Add(Sale sale)
       {
           return _saleRepository.Add(sale);
       }

       public List<Sale> GetAll()
        {
            return _saleRepository.GetAll();
        }

        public int GetSoldProductQtyByIdAndDate(int productId, DateTime soldDate)
        {
            return _saleRepository.GetSoldProductQtyByIdAndDate(productId, soldDate);
        }

        public string GetLastSaleCode()
        {
            return _saleRepository.GetLastSaleCode();
        }
    }
}
