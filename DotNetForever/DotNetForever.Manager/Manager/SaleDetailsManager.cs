using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetForever.Model.Model;
using DotNetForever.Repository.Repository;

namespace DotNetForever.Manager.Manager
{
    public class SaleDetailsManager
    {
        SaleDetailsRepository _saleDetailsRepository=new SaleDetailsRepository();
        public List<SaleDetail> GetAllSaleDetailBySaleId(int saleId)
        {
            return _saleDetailsRepository.GetAllSaleDetailBySaleId(saleId);
        }
    }
}
