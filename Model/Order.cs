using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrdering.Models
{
    // Define the OrderStatus enum
    public enum OrderStatus
    {
        Pending,
        Completed,
        Cancelled
    }

    public class Order
    {
        public int OrderId { get; set; }

        [Display(Name = "Customer")]
        public int CustomerProfileId { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Order Status")]
        public OrderStatus Status { get; set; }

        [Display(Name = "Restaurant")]
        public int RestaurantInfoId { get; set; }
        public RestaurantInfo? RestaurantInfo { get; set; }

        // Navigation properties
        public CustomerProfile? CustomerProfile { get; set; }
        public DeliveryInfo? DeliveryInfo { get; set; }
    }
}
