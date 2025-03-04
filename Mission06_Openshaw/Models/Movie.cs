using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Openshaw.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        // Foreign Key
        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }  

        // Navigation property
        [ForeignKey("CategoryId")] 
        public Category Category { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty; // ✅ Prevent null issues

        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, 3000, ErrorMessage = "Year must be between 1888 and 3000.")]
        public int Year { get; set; }
        
        public string? Director { get; set; }  // ✅ Make nullable to avoid errors

        public string? Rating { get; set; }  // ✅ Make nullable

        [Required(ErrorMessage = "Edited is required")]
        public bool Edited { get; set; }  // ✅ Change from `bool?` to `bool`

        public string? LentTo { get; set; }  // ✅ Make nullable

        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }  // ✅ Make nullable

        [Required(ErrorMessage = "Copied to Plex is required")]
        public bool CopiedToPlex { get; set; }
    }
}