using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrdering.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Menu Item Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(300)]
        public string Description { get; set; } = string.Empty;

        [Range(0.01, 999.99)]
        public decimal Price { get; set; }

        [Display(Name = "Restaurant")]
        public int RestaurantInfoId { get; set; }

        public RestaurantInfo? RestaurantInfo { get; set; }
    }
}
