using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrdering.Models;
using Online_Food_Ordering.Data;

namespace Online_Food_Ordering.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Online_Food_OrderingContext _context;

        public IndexModel(Online_Food_OrderingContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get; set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                Order = await _context.Order
                    .Include(o => o.CustomerProfile)  
                    .Include(o => o.MenuItem)        
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
               
                Order = new List<Order>(); 
            }
        }
    }
}
