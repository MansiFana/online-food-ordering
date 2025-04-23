using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrdering.Models;
using Online_Food_Ordering.Data;

namespace Online_Food_Ordering.Pages.CustomerProfiles
{
    public class DetailsModel : PageModel
    {
        private readonly Online_Food_Ordering.Data.Online_Food_OrderingContext _context;

        public DetailsModel(Online_Food_Ordering.Data.Online_Food_OrderingContext context)
        {
            _context = context;
        }

        public CustomerProfile CustomerProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerprofile = await _context.CustomerProfile.FirstOrDefaultAsync(m => m.CustomerProfileId == id);

            if (customerprofile is not null)
            {
                CustomerProfile = customerprofile;

                return Page();
            }

            return NotFound();
        }
    }
}
