using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetForever.Model.Model
{
    public class Product
    {
        public int Id { set; get; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Code is required")]
        public string Code { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("Recorder Level")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Recorder Level is required")]
        public int RecorderLevel { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public virtual Category Category {get; set; }
    }
}
