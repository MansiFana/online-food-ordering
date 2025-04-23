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

namespace Online_Food_Ordering.Pages.MenuItems
{
    public class EditModel : PageModel
    {
        private readonly Online_Food_Ordering.Data.Online_Food_OrderingContext _context;

        public EditModel(Online_Food_Ordering.Data.Online_Food_OrderingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MenuItem MenuItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem =  await _context.MenuItem.FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (menuitem == null)
            {
                return NotFound();
            }
            MenuItem = menuitem;
           ViewData["RestaurantInfoId"] = new SelectList(_context.RestaurantInfo, "RestaurantInfoId", "Name");
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

            _context.Attach(MenuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(MenuItem.MenuItemId))
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

        private bool MenuItemExists(int id)
        {
            return _context.MenuItem.Any(e => e.MenuItemId == id);
        }
    }
}
