using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewSound.Data;
using NewSound.Models;

namespace NewSound.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly NewSound.Data.NewSoundContext _context;

        public IndexModel(NewSound.Data.NewSoundContext context)
        {
            _context = context;
        }

        public string TitleSort { get; set; }
        public string DateSort { get; set; }

        public IList<Ticket> Tickets { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder)
        {
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<Ticket> sortArtist = from t in _context.Ticket
                                            select t;

            switch (sortOrder)
            {
                case "name_desc":
                    sortArtist = sortArtist.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    sortArtist = sortArtist.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    sortArtist = sortArtist.OrderByDescending(s => s.Date);
                    break;
                default:
                    sortArtist = sortArtist.OrderBy(s => s.Title);
                    break;
            }
            Tickets = await sortArtist.AsNoTracking().Include(t => t.ConcertHall).ToListAsync();
        }
    }
}
