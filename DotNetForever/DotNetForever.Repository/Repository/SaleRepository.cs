using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using DotNetForever.DatabaseContext.DatabaseContext;
using DotNetForever.Model.Model;

namespace DotNetForever.Repository.Repository
{
    public class SaleRepository
    {
        public List<Sale> GetAll()
        {
            using (var context = new SMSDbContext())
            {
                return context.Sales.Include(x=>x.Customer).ToList();

            }
        }

        public int GetSoldProductQtyByIdAndDate(int productId, DateTime soldDate)
        {
            int total = 0;
            using (var context = new SMSDbContext())
            {

                total = context.SaleDetails.Where(x => x.Product.Id == productId && x.Sale.DateTime <= soldDate).Select(c => c.Quantity).DefaultIfEmpty(0).Sum();
            }

            return total;
        }
    }
}
