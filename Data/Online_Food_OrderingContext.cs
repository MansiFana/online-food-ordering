using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrdering.Models;

namespace Online_Food_Ordering.Data
{
    public class Online_Food_OrderingContext : DbContext
    {
        public Online_Food_OrderingContext (DbContextOptions<Online_Food_OrderingContext> options)
            : base(options)
        {
        }

        public DbSet<OnlineFoodOrdering.Models.CustomerProfile> CustomerProfile { get; set; } = default!;
        public DbSet<OnlineFoodOrdering.Models.DeliveryInfo> DeliveryInfo { get; set; } = default!;
        public DbSet<OnlineFoodOrdering.Models.MenuItem> MenuItem { get; set; } = default!;
        public DbSet<OnlineFoodOrdering.Models.Order> Order { get; set; } = default!;
        public DbSet<OnlineFoodOrdering.Models.RestaurantInfo> RestaurantInfo { get; set; } = default!;

    }
}
