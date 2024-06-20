using System.ComponentModel.DataAnnotations;

namespace NewSound.Models
{
    public class Bar
    {
        public int BarID { get; set; }

        [Required(ErrorMessage = "What is the name of the drink?")]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Cocktail")]
        public string? Drink { get; set; }

        [Required(ErrorMessage = "What type of alcohol?")]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Alcohol")]
        public string? Alkohol { get; set; }

        [Required(ErrorMessage = "How much is it in ounces?")]
        [Range(1, 5)]
        [Display(Name = "In ounces")]
        public string? Amount { get; set; }

        [Required(ErrorMessage = "There must be some ingredients, right?")]
        [MinLength(3)]
        [Display(Name = "Ingredients")]
        public string? Ingredient { get; set;}

        public ICollection<ConcertHall>? ConcertHalls { get; set; }
    }
}
