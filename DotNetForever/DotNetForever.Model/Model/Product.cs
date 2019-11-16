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
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ReorderLevel { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual Category Category {get; set; }
    }
}
