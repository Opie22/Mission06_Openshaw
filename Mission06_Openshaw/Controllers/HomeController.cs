using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Openshaw.Models;
// Make sure you have the using statement for your context!
using Microsoft.EntityFrameworkCore;

namespace Mission06_Openshaw.Controllers;

public class HomeController : Controller
{
    // 1. Declare the private field FIRST
    private readonly MovieContext _context;

    // 2.  Constructor to receive the dependency (MovieContext)
    public HomeController(MovieContext context)
    {
        _context = context;
    }

    // 3. Now the Action Methods, which can use _context
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddMovie()
    {
        ViewBag.Categories = _context.Categories.ToList(); // Get categories
        return View(new Movie());
    }
    
    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList"); // Redirect to the movie list
        }
        // IMPORTANT: Repopulate ViewBag.Categories if validation fails!
        ViewBag.Categories = _context.Categories.ToList();
        return View(movie);
    }
    
    
    // Display Movie List
    public IActionResult MovieList()
    {
        var movies = _context.Movies
            .Include(m => m.Category)
            .Select(m => new Movie
            {
                MovieId = m.MovieId,
                CategoryId = m.CategoryId,
                CopiedToPlex = m.CopiedToPlex,
                Director = m.Director ?? "Unknown",  // ✅ Handle NULL
                Edited = m.Edited,  
                LentTo = m.LentTo ?? "N/A",  // ✅ Handle NULL
                Notes = m.Notes ?? "",  // ✅ Handle NULL
                Rating = m.Rating ?? "Unrated",  // ✅ Handle NULL
                Title = m.Title,
                Year = m.Year,
                Category = m.Category
            })
            .ToList();

        return View(movies);
    }

    // Edit (GET - Display form)
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _context.Movies
            .Include(m => m.Category) // Include the Category
            .FirstOrDefault(m => m.MovieId == id);

        if (movie == null)
        {
            return NotFound();
        }

        ViewBag.Categories = _context.Categories.ToList(); // Get categories
        return View(movie);
    }

    // Edit (POST - Handle form submission)
    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }
        // IMPORTANT: Repopulate ViewBag.Categories if validation fails!
        ViewBag.Categories = _context.Categories.ToList();
        return View(movie);
    }
    
    // Delete (GET - Confirmation)
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
        if (movie == null)
        {
            return NotFound(); // Or handle appropriately
        }
        return View(movie);
    }

    // Delete (POST - Perform deletion)
    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);

        if (movie != null)
        {
            string title = movie.Title; // Store the title before deleting
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            TempData["Message"] = $"The movie \"{title}\" was successfully deleted.";
        }

        return RedirectToAction("MovieList");
    }

    
}