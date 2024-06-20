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
    public class IndexModel : PageModel
    {
        private readonly NewSound.Data.NewSoundContext _context;

        public IndexModel(NewSound.Data.NewSoundContext context)
        {
            _context = context;
        }

        public string PlaceSort { get; set; }
        public string CitySort { get; set; }

        public IList<ConcertHall> ConcertHalls { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder)
        {
            PlaceSort = String.IsNullOrEmpty(sortOrder) ? "place_desc" : "";
            CitySort = sortOrder == "City" ? "city_desc" : "City";

            IQueryable<ConcertHall> sortConcert = from c in _context.ConcertHall
                                            select c;

            switch (sortOrder)
            {
                case "place_desc":
                    sortConcert = sortConcert.OrderByDescending(s => s.Place);
                    break;
                case "City":
                    sortConcert = sortConcert.OrderBy(s => s.City);
                    break;
                case "city_desc":
                    sortConcert = sortConcert.OrderByDescending(s => s.City);
                    break;
                default:
                    sortConcert = sortConcert.OrderBy(s => s.Place);
                    break;
            }
            ConcertHalls = await sortConcert.AsNoTracking().Include(c => c.Bar).ToListAsync();
        }
    }
}
