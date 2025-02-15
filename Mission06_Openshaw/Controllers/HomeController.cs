using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Openshaw.Models;

namespace Mission06_Openshaw.Controllers;

public class HomeController : Controller
{
        private MovieContext _context;

        public HomeController(MovieContext context) // Correct constructor
        {
            _context = context;
        }

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
            return View();
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
            return View(movie); // Return the view with validation errors.
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
