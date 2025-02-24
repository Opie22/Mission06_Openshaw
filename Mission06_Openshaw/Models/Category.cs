using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; // Required for ICollection

namespace Mission06_Openshaw.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } // Or whatever the PK column name is

        [Required]
        public string CategoryName { get; set; } // Or whatever the category name column is

        // Navigation property:  A Category can have many Movies
        public ICollection<Movie> Movies { get; set; }
    }
}