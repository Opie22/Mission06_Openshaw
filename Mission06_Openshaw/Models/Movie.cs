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
                public int CategoryId { get; set; }  // Foreign key property

                // Navigation property: A Movie belongs to one Category
                [ForeignKey("CategoryId")] // Explicitly specify the foreign key
                public Category Category { get; set; }

                [Required(ErrorMessage = "Title is required.")]
                public string Title { get; set; }

                [Required(ErrorMessage = "Year is required.")]
                [Range(1888, 3000, ErrorMessage = "Year must be between 1888 and 3000.")]
                public int Year { get; set; }

                [Required(ErrorMessage = "Director is required.")]
                public string Director { get; set; } // Match database column name

                [Required(ErrorMessage = "Rating is required.")]
                public string Rating { get; set; }

                [Required(ErrorMessage = "Edited is required")]
                public bool? Edited { get; set; } // Match database column name

                public string? LentTo { get; set; }

                [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
                public string? Notes { get; set; }

                [Required(ErrorMessage = "Copied to Plex is required")]
                public bool CopiedToPlex { get; set; } // Match database column name
        }
}