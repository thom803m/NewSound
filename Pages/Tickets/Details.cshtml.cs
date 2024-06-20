using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewSound.Data;
using NewSound.Models;

namespace NewSound.Pages.Tickets
{
    public class DetailsModel : PageModel
    {
        private readonly NewSound.Data.NewSoundContext _context;

        public DetailsModel(NewSound.Data.NewSoundContext context)
        {
            _context = context;
        }

      public Ticket Ticket { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ticket == null)
            {
                return NotFound();
            }

            Ticket = await _context.Ticket
                .Include(c => c.ConcertHall).FirstOrDefaultAsync(m => m.TicketID == id);

            if (Ticket == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
