using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetForever.Model.Model
{
    public class Sale
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateTime { get; set; }
        public string Code { get; set; }
        public List<SaleDetail> SaleDetails { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
