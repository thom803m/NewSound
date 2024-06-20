using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewSound.Models;

namespace NewSound.Data
{
    public class NewSoundContext : DbContext
    {
        public NewSoundContext (DbContextOptions<NewSoundContext> options)
            : base(options)
        {
        }

        public DbSet<NewSound.Models.Bar> Bar { get; set; } = default!;

        public DbSet<NewSound.Models.ConcertHall>? ConcertHall { get; set; }

        public DbSet<NewSound.Models.Restaurant>? Restaurant { get; set; }

        public DbSet<NewSound.Models.Ticket>? Ticket { get; set; }
    }
}
