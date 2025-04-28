using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineFoodOrdering.Models;
using Online_Food_Ordering.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Online_Food_Ordering.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly Online_Food_Ordering.Data.Online_Food_OrderingContext _context;

        public CreateModel(Online_Food_Ordering.Data.Online_Food_OrderingContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            ViewData["CustomerProfileId"] = new SelectList(_context.CustomerProfile, "CustomerProfileId", "Email");
            ViewData["RestaurantInfoId"] = new SelectList(_context.RestaurantInfo, "RestaurantInfoId", "Name");
            // Pass the OrderStatus enum values to the view
            ViewData["OrderStatus"] = new SelectList(Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>());

            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}