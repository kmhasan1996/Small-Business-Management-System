using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetForever.Repository.Repository;
using DotNetForever.Web.Models;
using DotNetForever.Web.ViewModels;

namespace DotNetForever.Manager.Manager
{
    public class SharedManager
    {
        private SharedRepository _sharedRepository=new SharedRepository();

        public List<Stock> GetStockReport(int? categoryId, int? productId, DateTime startDate, DateTime endDate)
        {
            return _sharedRepository.GetStockReport(categoryId, productId, startDate, endDate);
        }

        public List<PurchaseReport> GetPurchaseReport(DateTime startDate, DateTime endDate)
        {
            return _sharedRepository.GetPurchaseReport(startDate, endDate);
        }
    }
}
