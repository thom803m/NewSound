using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewSound.Data;
using NewSound.Models;

namespace NewSound.Pages.Bars
{
    public class DetailsModel : PageModel
    {
        private readonly NewSound.Data.NewSoundContext _context;

        public DetailsModel(NewSound.Data.NewSoundContext context)
        {
            _context = context;
        }

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
    }
}
