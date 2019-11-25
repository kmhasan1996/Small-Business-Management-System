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
    public class PurchaseRepository
    {
        public List<Purchase> GetAll()
        {
            using (var context=new SMSDbContext())
            {
                return context.Purchases.Include(x=>x.Supplier).ToList();

            }
        }

        public bool Add(Purchase purchase)
        {
            using (var context = new SMSDbContext())
            {
                context.Purchases.Add(purchase);
                return context.SaveChanges() > 0;
            }
        }


        public int GetTotalProductByIdAndDate(int productId, DateTime startDate)
        {
            int total = 0;
            using (var context = new SMSDbContext())
            {
              
                total = context.PurchaseDetails.Where(x => x.Product.Id == productId && x.Purchase.DateTime < startDate).Select(c => c.Quantity).DefaultIfEmpty(0).Sum();
            }

            return total;
        }

        public int GetTotalProductByIdAndStartAndEndDate(int productId, DateTime startDate, DateTime endDate)
        {

            int total = 0;
            using (var context = new SMSDbContext())
            {

                total = context.PurchaseDetails.Where(x => x.Product.Id == productId && x.Purchase.DateTime >= startDate && x.Purchase.DateTime <= endDate).Select(c => c.Quantity).DefaultIfEmpty(0).Sum();
            }

            return total;

        }


        public int GetPurchaseProductQtyByIdAndDate(int productId, DateTime startDate)
        {
            int total = 0;
            using (var context = new SMSDbContext())
            {

                total = context.PurchaseDetails.Where(x => x.Product.Id == productId && x.Purchase.DateTime <= startDate).Select(c => c.Quantity).DefaultIfEmpty(0).Sum();
            }

            return total;
        }
    }
}
