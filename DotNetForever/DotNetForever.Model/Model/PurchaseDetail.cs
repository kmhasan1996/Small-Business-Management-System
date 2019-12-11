using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetForever.Model.Model
{
    public class PurchaseDetail
    {
        public int Id { get; set; }

        public int PurchaseId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime ManufacturedDateTime { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime ExpireDate { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public double MRP { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public string Remarks { get; set; }

        public virtual  Purchase Purchase { get; set; }
        public virtual Product Product { get; set; }


    }
}
