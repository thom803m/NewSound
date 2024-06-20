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

namespace NewSound.Pages.ConcertHalls
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
      public ConcertHall ConcertHall { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ConcertHall == null)
            {
                return NotFound();
            }

            ConcertHall = await _context.ConcertHall
            .AsNoTracking()
            .Include(c => c.Bar)
            .FirstOrDefaultAsync(m => m.ConcertHallID == id);

            if (ConcertHall == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ConcertHall == null)
            {
                return NotFound();
            }

            ConcertHall = await _context.ConcertHall.FindAsync(id);

            if (ConcertHall != null)
            {
                _context.ConcertHall.Remove(ConcertHall);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
