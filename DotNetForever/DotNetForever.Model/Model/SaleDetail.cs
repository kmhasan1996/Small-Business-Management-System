using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetForever.Model.Model
{
    public class SaleDetail
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double MRP { get; set; }
        public double TotalPrice { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Product Product { get; set; }

    }
}
