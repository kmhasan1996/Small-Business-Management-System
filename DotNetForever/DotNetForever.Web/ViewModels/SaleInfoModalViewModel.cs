using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetForever.Model.Model;

namespace DotNetForever.Web.ViewModels
{
    public class SaleInfoModalViewModel
    {
        public List<SaleDetail> SaleDetails { get; set; }
        public Sale Sale { get; set; }
        public double SubTotal { get; set; }
        public int DiscountPercentage { get; set; }
        public double DiscountAmount { get; set; }
        public double PayaableAmount { get; set; }

    }
}