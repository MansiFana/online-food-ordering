using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrdering.Models;
using Online_Food_Ordering.Data;

namespace Online_Food_Ordering.Pages.DeliveryInfos
{
    public class DeleteModel : PageModel
    {
        private readonly Online_Food_Ordering.Data.Online_Food_OrderingContext _context;

        public DeleteModel(Online_Food_Ordering.Data.Online_Food_OrderingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeliveryInfo DeliveryInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryinfo = await _context.DeliveryInfo.FirstOrDefaultAsync(m => m.DeliveryInfoId == id);

            if (deliveryinfo is not null)
            {
                DeliveryInfo = deliveryinfo;

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

            var deliveryinfo = await _context.DeliveryInfo.FindAsync(id);
            if (deliveryinfo != null)
            {
                DeliveryInfo = deliveryinfo;
                _context.DeliveryInfo.Remove(DeliveryInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
