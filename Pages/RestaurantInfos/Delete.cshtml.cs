using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrdering.Models;
using Online_Food_Ordering.Data;

namespace Online_Food_Ordering.Pages.RestaurantInfos
{
    public class DeleteModel : PageModel
    {
        private readonly Online_Food_Ordering.Data.Online_Food_OrderingContext _context;

        public DeleteModel(Online_Food_Ordering.Data.Online_Food_OrderingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RestaurantInfo RestaurantInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantinfo = await _context.RestaurantInfo.FirstOrDefaultAsync(m => m.RestaurantInfoId == id);

            if (restaurantinfo is not null)
            {
                RestaurantInfo = restaurantinfo;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantinfo = await _context.RestaurantInfo.FindAsync(id);
            if (restaurantinfo != null)
            {
                RestaurantInfo = restaurantinfo;
                _context.RestaurantInfo.Remove(RestaurantInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
