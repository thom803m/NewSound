using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewSound.Data;
using NewSound.Models;

namespace NewSound.Pages.ConcertHalls
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly NewSound.Data.NewSoundContext _context;

        public CreateModel(NewSound.Data.NewSoundContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BarID"] = new SelectList(_context.Bar, "BarID", "Drink");
            return Page();
        }

        [BindProperty]
        public ConcertHall ConcertHall { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.ConcertHall == null || ConcertHall == null)
            {
                return Page();
            }

            _context.ConcertHall.Add(ConcertHall);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
