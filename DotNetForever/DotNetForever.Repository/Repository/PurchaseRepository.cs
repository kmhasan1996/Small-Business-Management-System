using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
                return context.Purchases.Include(x=>x.Supplier).OrderByDescending(x=>x.Id).ToList();

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


        public double GetTotalCostPriceByIdAndStartAndEndDate(int productId, DateTime startDate, DateTime endDate)
        {

            double total = 0;
            using (var context = new SMSDbContext())
            {

                total = context.PurchaseDetails.Where(x => x.Product.Id == productId && x.Purchase.DateTime >= startDate && x.Purchase.DateTime <= endDate).Select(c => (c.Quantity * c.UnitPrice)).DefaultIfEmpty(0).Sum();
            }

            return total;

        }

        public double GetTotalProfitByIdAndStartAndEndDate(int productId, DateTime startDate, DateTime endDate)
        {

            double total = 0;
            using (var context = new SMSDbContext())
            {

                total = context.PurchaseDetails.Where(x => x.Product.Id == productId && x.Purchase.DateTime >= startDate && x.Purchase.DateTime <= endDate).Select(c => c.Quantity * c.MRP).DefaultIfEmpty(0).Sum();
            }

            return total;

        }

        public string GetLastPurchaseCode()
        {
            string code = "";
            using (var context = new SMSDbContext())
            {
                code = context.Purchases.OrderByDescending(x => x.Id).Select(x => x.Code).FirstOrDefault();
            }

            return code;
        }


        public List<Purchase> Search(string search)
        {
            using (var context = new SMSDbContext())
            {
                return context.Purchases.Where(x => (x.Code.ToLower().Contains(search.ToLower()) || x.Supplier.Name.Contains(search))).ToList();


            }
        }

    }
}
