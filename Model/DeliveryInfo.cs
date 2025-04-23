using System;
using System.ComponentModel.DataAnnotations;


namespace OnlineFoodOrdering.Models
{
    public class DeliveryInfo
    {
        public int DeliveryInfoId { get; set; }

        [Display(Name = "Order")]
        public int OrderId { get; set; }

        [StringLength(200)]
        [Display(Name = "Delivery Address")]
        public string? DeliveryAddress { get; set; }

        [Display(Name = "Estimated Time")]
        public string? EstimatedTime { get; set; }

        [StringLength(50)]
        public string? Status { get; set; }

        public Order? Order { get; set; }
    }
}
