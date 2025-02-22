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
        return View(new Movie());
    }
    
    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie); // Now _context is properly initialized
            _context.SaveChanges();
            return View("Confirmation", movie); // Pass the movie object for confirmation
        }
        return View(movie); // Return the view with validation errors.
    }

    public IActionResult MovieList()
    {
        List<Movie> movies = _context.Movies.ToList();
        return View(movies);
    }
}