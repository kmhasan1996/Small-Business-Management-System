using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetForever.Model.Model;

namespace DotNetForever.Web.ViewModels
{
    public class SaleDetailViewModel
    {
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public SaleDetail SaleDetail { get; set; }
        public string Code { get; set; }
    }
}