using System.ComponentModel.DataAnnotations;

namespace colors.Controllers.Resources
{
    public class EntryResource
    {
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [StringLength(100)]
        public string Color { get; set; }

    }
}