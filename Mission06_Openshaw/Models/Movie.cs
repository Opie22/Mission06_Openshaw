using System.ComponentModel.DataAnnotations;

namespace Mission06_Openshaw.Models;

public class Movie
{
        [Key]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, 3000, ErrorMessage = "Year must be between 1888 and 3000.")] // Changed max year
        public int Year { get; set; }

        [Required(ErrorMessage = "Director is required.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "Edited is required")]
        public bool? Edited { get; set; } // Required, but still nullable bool

        public string? LentTo { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "Copied to Plex is required")] //NEW FIELD
        public bool CopiedToPlex {get; set;}
    
}

