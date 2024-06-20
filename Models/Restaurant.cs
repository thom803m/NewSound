using System.ComponentModel.DataAnnotations;

namespace NewSound.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }

        [Required(ErrorMessage = "What is the name of the restaurant?")]
        [StringLength(30, MinimumLength = 5)]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "What is their cuisine?")]
        [StringLength(20, MinimumLength = 4)]
        [Display(Name = "Cuisine")]
        public string? Cuisine { get; set; }

        [Required(ErrorMessage = "What is their best served dish?")]
        [StringLength(30, MinimumLength = 5)]
        [Display(Name = "Specialty")]
        public string? Specialty { get; set; }

        [Required(ErrorMessage = "What is the distance in miles?")]
        [Range(0, 10)]
        [Display(Name = "Distance in miles")]
        public int Mile { get; set; }

        public int ConcertHallID { get; set; }

        [Display(Name = "Close to")]
        public ConcertHall? ConcertHall { get; set; }
    }
}
