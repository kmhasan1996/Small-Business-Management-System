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
    }
}
