using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewSound.Data;
using NewSound.Models;

namespace NewSound.Pages.ConcertHalls
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly NewSound.Data.NewSoundContext _context;

        public EditModel(NewSound.Data.NewSoundContext context)
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

            ConcertHall =  await _context.ConcertHall.FirstOrDefaultAsync(m => m.ConcertHallID == id);
            if (ConcertHall == null)
            {
                return NotFound();
            }
            ViewData["BarID"] = new SelectList(_context.Bar, "BarID", "Drink");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ConcertHall).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcertHallExists(ConcertHall.ConcertHallID))
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

        private bool ConcertHallExists(int id)
        {
          return (_context.ConcertHall?.Any(e => e.ConcertHallID == id)).GetValueOrDefault();
        }
    }
}
