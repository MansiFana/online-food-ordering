using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrdering.Models;
using Online_Food_Ordering.Data;

namespace Online_Food_Ordering.Pages.RestaurantInfos
{
    public class EditModel : PageModel
    {
        private readonly Online_Food_Ordering.Data.Online_Food_OrderingContext _context;

        public EditModel(Online_Food_Ordering.Data.Online_Food_OrderingContext context)
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

            var restaurantinfo =  await _context.RestaurantInfo.FirstOrDefaultAsync(m => m.RestaurantInfoId == id);
            if (restaurantinfo == null)
            {
                return NotFound();
            }
            RestaurantInfo = restaurantinfo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RestaurantInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantInfoExists(RestaurantInfo.RestaurantInfoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RestaurantInfoExists(int id)
        {
            return _context.RestaurantInfo.Any(e => e.RestaurantInfoId == id);
        }
    }
}
