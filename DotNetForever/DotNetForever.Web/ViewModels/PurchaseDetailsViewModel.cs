using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetForever.Model.Model;

namespace DotNetForever.Web.ViewModels
{
    public class PurchaseDetailsViewModel
    {
        public List<Supplier> Suppliers { get; set; }
        public List<Category> Categories { get; set; }
        //public PurchaseDetail PurchaseDetail { get; set; }
        public string Code { get; set; }
    }
}