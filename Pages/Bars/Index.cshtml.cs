using System;
using System.Collections;
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
    public class IndexModel : PageModel
    {
        private readonly NewSound.Data.NewSoundContext _context;

        public IndexModel(NewSound.Data.NewSoundContext context)
        {
            _context = context;
        }

        public IList<Bar> Bars { get;set; } = default!;
        public ICollection<ConcertHall> ConcertHalls { get; set; } = default!;
        public int BarID { get; set; }

        public async Task OnGetAsync(int? id, int ConcertHallID)
        {
            Bars = await _context.Bar
                .Include(c => c.ConcertHalls)
                .OrderBy(a => a.Alkohol)
                .ToListAsync();

            if (id != null)
            {
                BarID = id.Value;
                Bar concertInfo = Bars
                    .Where(i => i.BarID == id.Value).Single();
                ConcertHalls = concertInfo.ConcertHalls;
            }

            if (_context.Bar != null)
            {
                Bars = await _context.Bar.ToListAsync();
            }
        }
    }
}
