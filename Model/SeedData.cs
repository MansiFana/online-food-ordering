using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Online_Food_Ordering.Data;
using OnlineFoodOrdering.Models;
using System;
using System.Linq;

namespace OnlineFoodOrdering
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<Online_Food_OrderingContext>())
            {
                // Check if the database has already been seeded
                if (context.RestaurantInfo.Any() || context.MenuItem.Any() || context.CustomerProfile.Any() || context.Order.Any() || context.DeliveryInfo.Any())
                {
                    return; // DB has been seeded
                }

                // Seed RestaurantInfo
                var restaurants = new RestaurantInfo[]
                {
                    new RestaurantInfo { Name = "Pizza Place", Address = "123 Main St", PhoneNumber = "555-1234", CuisineType = "Italian" },
                    new RestaurantInfo { Name = "Sushi World", Address = "456 Ocean Ave", PhoneNumber = "555-5678", CuisineType = "Japanese" },
                    new RestaurantInfo { Name = "Taco Town", Address = "789 Fiesta Rd", PhoneNumber = "555-8765", CuisineType = "Mexican" },
                    new RestaurantInfo { Name = "Burger Barn", Address = "321 Grill Ln", PhoneNumber = "555-4321", CuisineType = "American" },
                    new RestaurantInfo { Name = "Curry House", Address = "111 Spice St", PhoneNumber = "555-2468", CuisineType = "Indian" }
                };
                context.RestaurantInfo.AddRange(restaurants);
                context.SaveChanges();

                // Seed MenuItem
                var menuItems = new MenuItem[]
                {
                    new MenuItem { Name = "Margherita Pizza", Price = 10.99M, RestaurantInfoId = restaurants[0].RestaurantInfoId },
                    new MenuItem { Name = "California Roll", Price = 8.49M, RestaurantInfoId = restaurants[1].RestaurantInfoId },
                    new MenuItem { Name = "Beef Taco", Price = 3.99M, RestaurantInfoId = restaurants[2].RestaurantInfoId },
                    new MenuItem { Name = "Cheeseburger", Price = 6.99M, RestaurantInfoId = restaurants[3].RestaurantInfoId },
                    new MenuItem { Name = "Chicken Curry", Price = 9.49M, RestaurantInfoId = restaurants[4].RestaurantInfoId }
                };
                context.MenuItem.AddRange(menuItems);
                context.SaveChanges();

                // Seed CustomerProfile
                var customers = new CustomerProfile[]
                {
                    new CustomerProfile { FullName = "John Doe", Email = "john@example.com" },
                    new CustomerProfile { FullName = "Jane Smith", Email = "jane@example.com" },
                    new CustomerProfile { FullName = "Alice Johnson", Email = "alice@example.com" },
                    new CustomerProfile { FullName = "Bob Brown", Email = "bob@example.com" },
                    new CustomerProfile { FullName = "Eve Davis", Email = "eve@example.com" }
                };
                context.CustomerProfile.AddRange(customers);
                context.SaveChanges();

                // Seed Orders
                var orders = new Order[]
                {
                    new Order { CustomerProfileId = customers[0].CustomerProfileId, MenuItemId = menuItems[0].MenuItemId, Quantity = 2, Status = OrderStatus.Pending},
                    new Order { CustomerProfileId = customers[1].CustomerProfileId, MenuItemId = menuItems[1].MenuItemId, Quantity = 1, Status = OrderStatus.Pending },
                    new Order { CustomerProfileId = customers[2].CustomerProfileId, MenuItemId = menuItems[2].MenuItemId, Quantity = 3, Status = OrderStatus.Pending },
                    new Order { CustomerProfileId = customers[3].CustomerProfileId, MenuItemId = menuItems[3].MenuItemId, Quantity = 2, Status = OrderStatus.Pending },
                    new Order { CustomerProfileId = customers[4].CustomerProfileId, MenuItemId = menuItems[4].MenuItemId, Quantity = 1, Status = OrderStatus.Pending }
                };
                context.Order.AddRange(orders);
                context.SaveChanges();

                // Seed DeliveryInfo
                var deliveries = new DeliveryInfo[]
                {
                   new DeliveryInfo { OrderId = orders[0].OrderId, DeliveryAddress = "123 Main St", EstimatedTime = DateTime.Now.AddHours(1).ToString("f") },
                   new DeliveryInfo { OrderId = orders[1].OrderId, DeliveryAddress = "456 Ocean Ave", EstimatedTime = DateTime.Now.AddHours(1.5).ToString("f") },
                   new DeliveryInfo { OrderId = orders[2].OrderId, DeliveryAddress = "789 Fiesta Rd", EstimatedTime = DateTime.Now.AddHours(2).ToString("f") },
                   new DeliveryInfo { OrderId = orders[3].OrderId, DeliveryAddress = "321 Grill Ln", EstimatedTime = DateTime.Now.AddHours(2.5).ToString("f") },
                   new DeliveryInfo { OrderId = orders[4].OrderId, DeliveryAddress = "111 Spice St", EstimatedTime = DateTime.Now.AddHours(3).ToString("f") }

                };
                context.DeliveryInfo.AddRange(deliveries);
                context.SaveChanges();
            }
        }
    }
}
