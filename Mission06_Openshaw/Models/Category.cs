using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; // Required for ICollection

namespace Mission06_Openshaw.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } //  column name

        [Required]
        public string  CategoryName { get; set; } //  category name column 

        // Navigation property:  A Category can have many Movies
        public ICollection<Movie>? Movies { get; set; }
    }
}