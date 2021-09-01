using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colors.Models
{
    [Table("Entries")]
    public class Entry
    {
        public int Id { get; set; }
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
        [Required]
        public DateTime EntryDate { get; set; }
    }
}