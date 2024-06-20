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

namespace NewSound.Pages.Bars
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
        public Bar Bar { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bar == null)
            {
                return NotFound();
            }

            Bar =  await _context.Bar.FirstOrDefaultAsync(m => m.BarID == id);

            if (Bar == null)
            {
                return NotFound();
            }
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

            _context.Attach(Bar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarExists(Bar.BarID))
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

        private bool BarExists(int id)
        {
          return (_context.Bar?.Any(e => e.BarID == id)).GetValueOrDefault();
        }
    }
}
