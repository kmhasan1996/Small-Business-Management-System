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
    }
}
