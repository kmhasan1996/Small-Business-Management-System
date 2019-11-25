using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetForever.Model.Model;
using DotNetForever.Repository.Repository;

namespace DotNetForever.Manager.Manager
{
    public class PurchaseDetailsManager
    {
        PurchaseDetailsRepository _purchaseDetailsRepository = new PurchaseDetailsRepository();

        public PurchaseDetail GetPurchaseDetailByProductId(int productId)
        {
            return _purchaseDetailsRepository.GetPurchaseDetailByProductId(productId);
        }

        public List<PurchaseDetail> GetAllPurchaseDetailByPurchaseId(int purchaseId)
        {
            return _purchaseDetailsRepository.GetAllPurchaseDetailByPurchaseId(purchaseId);
        }


    }
}
