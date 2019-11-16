using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetForever.Model.Model
{
    public class Supplier
    {
        public int Id { set; get; }
        [Required]
        public string Code { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string Address { set; get; }
        [Required]
        public string Email { set; get; }
        [Required]
        public string Contact { set; get; }
        [Required]
        public string ContactPerson { set; get; }
        public List<Purchase> Purchases { get; set; }
    }
}
