using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetForever.Model.Model
{
    public class Sale
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string Code { get; set; }
        public int DiscountPercentage { get; set; }
        public List<SaleDetail> SaleDetails { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
