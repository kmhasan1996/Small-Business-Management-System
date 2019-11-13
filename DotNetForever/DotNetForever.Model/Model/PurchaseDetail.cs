using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetForever.Model.Model
{
    public class PurchaseDetail
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public DateTime ManufacturedDateTime { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double MRP { get; set; }
        public double TotalPrice { get; set; }
        public string Remarks { get; set; }
        public virtual  Purchase Purchase { get; set; }
        public virtual Product Product { get; set; }


    }
}
