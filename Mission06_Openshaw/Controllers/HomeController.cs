using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Openshaw.Models;

namespace Mission06_Openshaw.Controllers;

public class HomeController : Controller
{
    
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

    private Movie _context; // Declare the field

    public HomeController(Movie context)
    {
        _context = context;
    }
    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index"); // Redirect to home after successful submission.
        }
        return View(movie); // Return the view with validation errors and the movie.
    }
    
    


}
