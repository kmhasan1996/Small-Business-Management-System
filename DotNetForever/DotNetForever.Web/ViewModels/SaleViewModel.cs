using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetForever.Model.Model;

namespace DotNetForever.Web.ViewModels
{
    public class SaleViewModel
    {
        public List<Sale> Sales { get; set; }
        public String Search { get; set; }
    }
}