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
    public class IndexModel : PageModel
    {
        private readonly Online_Food_Ordering.Data.Online_Food_OrderingContext _context;

        public IndexModel(Online_Food_Ordering.Data.Online_Food_OrderingContext context)
        {
            _context = context;
        }

        public IList<DeliveryInfo> DeliveryInfo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            DeliveryInfo = await _context.DeliveryInfo
                .Include(d => d.Order).ToListAsync();
        }
    }
}
