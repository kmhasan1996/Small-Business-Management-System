﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetForever.Model.Model;

namespace DotNetForever.Web.ViewModels
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }
        public string Search { get; set; }

    }
}