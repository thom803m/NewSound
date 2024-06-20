using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewSound.Data;
using NewSound.Models;

namespace NewSound.Pages.Tickets
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly NewSound.Data.NewSoundContext _context;

        public DeleteModel(NewSound.Data.NewSoundContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Ticket Ticket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ticket == null)
            {
                return NotFound();
            }

            Ticket = await _context.Ticket
            .AsNoTracking()
            .Include(c => c.ConcertHall)
            .FirstOrDefaultAsync(m => m.TicketID == id);

            if (Ticket == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Ticket == null)
            {
                return NotFound();
            }

            Ticket = await _context.Ticket.FindAsync(id);

            if (Ticket != null)
            {
                _context.Ticket.Remove(Ticket);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
