using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrdering.Models
{
    public class CustomerProfile
    {
        public int CustomerProfileId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string? FullName { get; set; } 

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(20)]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        public ICollection<Order> Orders { get; set; }= new List<Order>();
    }
}
