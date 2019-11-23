using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetForever.Repository.Repository;
using DotNetForever.Web.Models;

namespace DotNetForever.Manager.Manager
{
    public class SharedManager
    {
        private SharedRepository _sharedRepository=new SharedRepository();

        public List<Stock> GetStockReport(DateTime startDate, DateTime endDate)
        {
            return _sharedRepository.GetStockReport(startDate, endDate);
        }
    }
}
