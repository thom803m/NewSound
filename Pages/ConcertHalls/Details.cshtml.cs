using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewSound.Data;
using NewSound.Models;

namespace NewSound.Pages.ConcertHalls
{
    public class DetailsModel : PageModel
    {
        private readonly NewSound.Data.NewSoundContext _context;

        public DetailsModel(NewSound.Data.NewSoundContext context)
        {
            _context = context;
        }

      public ConcertHall ConcertHall { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ConcertHall == null)
            {
                return NotFound();
            }

            ConcertHall = await _context.ConcertHall
                .Include(c => c.Bar).FirstOrDefaultAsync(m => m.ConcertHallID == id);

            if (ConcertHall == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
