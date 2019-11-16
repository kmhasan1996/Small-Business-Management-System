using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetForever.Model.Model;

namespace DotNetForever.Web.ViewModels
{
    public class CreateProductViewModel
    {
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }

    }
}