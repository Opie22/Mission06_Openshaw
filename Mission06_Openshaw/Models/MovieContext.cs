using Microsoft.EntityFrameworkCore;

namespace Mission06_Openshaw.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base  (options) { } //constructor
    
    
    public DbSet<Movie> Movies { get; set; }

}