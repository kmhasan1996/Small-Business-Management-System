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
        public int CategoryId { get; set; }
        public string Code { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("Recorder Level")]
        public int RecorderLevel { get; set; }
        public string Description { get; set; }
        public virtual Category Category {get; set; }
    }
}
