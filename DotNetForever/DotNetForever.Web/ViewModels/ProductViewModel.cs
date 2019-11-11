using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetForever.Model.Model;

namespace DotNetForever.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { set; get; }
        public string Category { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int RecorderLevel { get; set; }
        public string Description { get; set; }
    }
}