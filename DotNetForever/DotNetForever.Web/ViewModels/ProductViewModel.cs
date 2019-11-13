using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DotNetForever.Model.Model;

namespace DotNetForever.Web.ViewModels
{
    public class ProductViewModel
    {
        public List<Category> Categories { get; set; }
        //public Product Product { get; set; }
        public int Id { set; get; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("Recorder Level")]
        [Required(ErrorMessage = "Recorder Level is required")]
        public int RecorderLevel { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}