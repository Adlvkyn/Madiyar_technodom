using System.ComponentModel.DataAnnotations;

namespace Technodom.Models
{
    public class Phones
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }

        [Range(80000, 950000)]
        public int Price { get; set; }

        [Range(64, 1024)]
        public int Storage { get; set; }

        [Display(Name = "Added Date")]
        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }
    }
}
