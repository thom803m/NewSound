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

namespace NewSound.Pages.Restaurants
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
        ViewData["ConcertHallID"] = new SelectList(_context.ConcertHall, "ConcertHallID", "Place");
            return Page();
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Restaurant == null || Restaurant == null)
            {
                return Page();
            }

            _context.Restaurant.Add(Restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
