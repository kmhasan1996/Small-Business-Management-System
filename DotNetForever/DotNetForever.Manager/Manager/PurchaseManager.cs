using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetForever.Model.Model;
using DotNetForever.Repository.Repository;

namespace DotNetForever.Manager.Manager
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();

        public List<Purchase> GetAll()
        {
            return _purchaseRepository.GetAll();
        }

        public bool Add(Purchase purchase)
        {
            return _purchaseRepository.Add(purchase);
        }

        public int GetPurchaseProductQtyByIdAndDate(int productId, DateTime startDate)
        {
            return _purchaseRepository.GetPurchaseProductQtyByIdAndDate(productId, startDate);
        }

        public string GetLastPurchaseCode()
        {
            return _purchaseRepository.GetLastPurchaseCode();
        }

        public List<Purchase> Search(string search)
        {
            return _purchaseRepository.Search(search);
        }
    }
}

