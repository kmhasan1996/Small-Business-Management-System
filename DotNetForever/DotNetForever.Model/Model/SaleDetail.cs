using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetForever.Model.Model
{
    public class SaleDetail
    {
        public int Id { get; set; }
  
        public int SaleId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double MRP { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Product Product { get; set; }

    }
}
