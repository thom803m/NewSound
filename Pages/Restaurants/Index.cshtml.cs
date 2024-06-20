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
    public class IndexModel : PageModel
    {
        private readonly NewSound.Data.NewSoundContext _context;

        public IndexModel(NewSound.Data.NewSoundContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurants { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchType { get; set; }
        public string? ErrorMessage { get; set; }

        public async Task OnGetAsync()
        {
            ErrorMessage = "";
            try
            {
                var restaurants = from m in _context.Restaurant
                             select m;
                if (!string.IsNullOrEmpty(SearchString))
                {
                    restaurants = restaurants.Where(s => s.Cuisine.Contains(SearchString));
                }
                Restaurants = await restaurants
                    .Include(r => r.ConcertHall).ToListAsync();
            }
            catch (Exception ex)
            {
                ErrorMessage = "Invalid Entry";
            }
        }
    }
}
