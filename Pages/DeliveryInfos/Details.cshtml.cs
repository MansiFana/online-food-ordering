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
    public class DetailsModel : PageModel
    {
        private readonly Online_Food_Ordering.Data.Online_Food_OrderingContext _context;

        public DetailsModel(Online_Food_Ordering.Data.Online_Food_OrderingContext context)
        {
            _context = context;
        }

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
    }
}
