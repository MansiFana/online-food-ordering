using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrdering.Models
{
    public class RestaurantInfo
    {
        public int RestaurantInfoId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        [StringLength(20)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(50)]
        [Display(Name = "Cuisine Type")]
        public string CuisineType { get; set; } = string.Empty;

        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
