using System.ComponentModel.DataAnnotations;

namespace Technodom.Models
{
    public class Laptops
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }

        [Range(150000, 2000000)]
        public int Price { get; set; }

        [Range(64, 2048)]
        public int Storage { get; set; }

        [Display(Name = "Added Date")]
        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }
    }
}
