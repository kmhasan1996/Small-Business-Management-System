using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetForever.Model.Model
{
    public class Category
    {
        public int Id { set; get; }

        [Required]
        public string Code { set; get; }

        [Required]
        public string Name { set; get; }
        public List<Product> Products { set; get; }
    }
}
