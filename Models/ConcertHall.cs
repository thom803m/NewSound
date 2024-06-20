using System.ComponentModel.DataAnnotations;

namespace NewSound.Models
{
    public class ConcertHall
    {
        public int ConcertHallID { get; set; }

        [Required(ErrorMessage = "What is the name of the place?")]
        [MinLength(4)]
        [Display(Name = "Concert hall")]
        public string? Place { get; set; }

        [Required(ErrorMessage = "Please give it an address?")]
        [MinLength(4)]
        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "In which city is the concert hall?")]
        [MinLength(4)]
        [Display(Name = "City")]
        public string? City { get; set; }

        [Required(ErrorMessage = "How many people can the concert hall take?")]
        [Range(50, 50000)]
        [Display(Name = "Capacity")]
        public int MaxAmount { get; set; }

        public int BarID { get; set; }

        [Display(Name = "Hottest drink")]
        public Bar? Bar { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }

        public ICollection<Restaurant>? Restaurants { get; set; }
    }
}
