using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetForever.Model.Model
{
    public class Purchase
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public DateTime DateTime { get; set; }
        public string InvoiceNo { get; set; }
        public string Code { get; set; }
        public List<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
