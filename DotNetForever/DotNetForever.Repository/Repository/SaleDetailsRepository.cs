﻿using DotNetForever.DatabaseContext.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetForever.Repository.Repository
{
    public class SaleDetailsRepository
    {

        public int GetTotalProductByIdAndDate(int productId, DateTime startDate)
        {
            int total = 0;
            using (var context = new SMSDbContext())
            {
                total = context.SaleDetails.Where(x => x.Product.Id == productId && x.Sale.DateTime < startDate).Select(c => c.Quantity).DefaultIfEmpty(0).Sum();

            }

            return total;
        }

        public int GetTotalProductByIdAndStartAndEndDate(int productId, DateTime startDate, DateTime endDate)
        {

            int total = 0;
            using (var context = new SMSDbContext())
            {

                total = context.SaleDetails.Where(x => x.Product.Id == productId && x.Sale.DateTime >= startDate && x.Sale.DateTime <= endDate).Select(c => c.Quantity).DefaultIfEmpty(0).Sum();
            }

            return total;

        }
    }
}
