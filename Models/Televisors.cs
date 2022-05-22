using System.ComponentModel.DataAnnotations;

namespace Technodom.Models
{
    public class Televisors
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }

        [Range(250000, 4000000)]
        public int Price { get; set; }

        [Range(25, 84)]
        public int Diagonal { get; set; }

        [Display(Name = "Added Date")]
        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }
    }
}
