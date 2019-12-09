using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetForever.Model.Model;

namespace DotNetForever.Web.ViewModels
{
    public class PurchaseInfoModalViewModel
    {
        public List<PurchaseDetail> PurchaseDetails { get; set; }
        public Purchase Purchase { get; set; }
        public double SubTotal { get; set; }
    }
}