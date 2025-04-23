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

        [Display(Name = "Menu Item")]
        public int MenuItemId { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        // Enum property to track the order status
        [Display(Name = "Order Status")]
        public OrderStatus Status { get; set; }
        public CustomerProfile? CustomerProfile { get; set; }
        public MenuItem? MenuItem { get; set; }

        public DeliveryInfo? DeliveryInfo { get; set; }
    }
}
