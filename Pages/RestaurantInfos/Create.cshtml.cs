using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineFoodOrdering.Models;
using Online_Food_Ordering.Data;

namespace Online_Food_Ordering.Pages.RestaurantInfos
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
            return Page();
        }

        [BindProperty]
        public RestaurantInfo RestaurantInfo { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RestaurantInfo.Add(RestaurantInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
