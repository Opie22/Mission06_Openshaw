using Microsoft.EntityFrameworkCore;

namespace Mission06_Openshaw.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        //Seed Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Category = "Action/Adventure",
                    Title = "Top Gun: Maverick",
                    Year = 2022,
                    Director = "Joseph Kosinski",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = null,
                    Notes = "So good!"
                },
                new Movie
                {
                    MovieId = 2,
                    Category = "Action/Adventure",
                    Title = "Avengers: Endgame",
                    Year = 2019,
                    Director = "Anthony Russo, Joe Russo",
                    Rating = "PG-13",
                    Edited = false
                },
                new Movie
                {
                    MovieId = 3,
                    Category = "Drama",
                    Title = "Oppenheimer",
                    Year = 2023,
                    Director = "Christopher Nolan",
                    Rating = "R",
                    Edited = false
                }
            );
        }
    }
}