using System.ComponentModel.DataAnnotations;

namespace NewSound.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }

        [Required(ErrorMessage = "Who is the coming artist/musician?")]
        [Display(Name = "Artist")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "How much will the ticket cost?")]
        [Display(Name = "Ticket price")]
        [DataType(DataType.Currency)]
        [Range(0, 3000)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "In what time will the artist play?")]
        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }

        [Required(ErrorMessage = "What date is the concert?")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int ConcertHallID { get; set; }

        [Display(Name = "Takes place in")]
        public ConcertHall? ConcertHall { get; set; }
    }
}
