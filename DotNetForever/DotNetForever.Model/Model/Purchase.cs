using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetForever.Model.Model
{
    public class Purchase
    {
        public int Id { get; set; }
        [Required]
        public int SupplierId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string InvoiceNo { get; set; }
        [Required]
        public string Code { get; set; }
        public List<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
