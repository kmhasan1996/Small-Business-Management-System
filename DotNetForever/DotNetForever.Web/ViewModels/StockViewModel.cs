using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetForever.Model.Model;
using DotNetForever.Web.Models;

namespace DotNetForever.Web.ViewModels
{
    public class StockViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Stock> Stocks { get; set; }
       
    }
}