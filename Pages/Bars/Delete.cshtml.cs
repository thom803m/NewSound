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

namespace NewSound.Pages.Bars
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
      public Bar Bar { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bar == null)
            {
                return NotFound();
            }

            Bar = await _context.Bar.FirstOrDefaultAsync(m => m.BarID == id);

            if (Bar == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Bar == null)
            {
                return NotFound();
            }

            Bar = await _context.Bar.FindAsync(id);

            if (Bar != null)
            {
                _context.Bar.Remove(Bar);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
