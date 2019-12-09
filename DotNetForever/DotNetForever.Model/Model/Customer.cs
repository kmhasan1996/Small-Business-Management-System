using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetForever.Model.Model
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public int LoyaltyPoint { get; set; }
        public List<Sale> Sales { get; set; }
       
    }
}
