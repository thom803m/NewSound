using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewSound.Data;
using NewSound.Models;

namespace NewSound.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly NewSound.Data.NewSoundContext _context;

        public DetailsModel(NewSound.Data.NewSoundContext context)
        {
            _context = context;
        }

      public Restaurant Restaurant { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Restaurant == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurant
                .Include(c => c.ConcertHall).FirstOrDefaultAsync(m => m.RestaurantID == id);

            if (Restaurant == null)
            {
                return NotFound();
            }
            else 
            {
                Restaurant = Restaurant;
            }
            return Page();
        }
    }
}
