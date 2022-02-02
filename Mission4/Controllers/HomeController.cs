using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext _movieContext { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, MovieContext movieContext)
        {
            _logger = logger;
            _movieContext = movieContext;
        }

        //Controller for the Index html page
        public IActionResult Index()
        {
            return View();
        }

        //Controller for the Podcast html page
        public IActionResult Podcast()
        {
            return View("Podcast");
        }

        //Controllers for the Movie Record html page, used for adding and editing movies in the database
        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            return View("Movies");
        }

        [HttpPost]
        public IActionResult Movies(AddMovie am)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(am);
                _movieContext.SaveChanges();
                return View("Confirmation", am);
            }
            else //If invalid
            {
                ViewBag.Categories = _movieContext.Categories.ToList();

                return View(am); 
            }
        }

        //Controller for the Movie table html page
        public IActionResult MovieDatabase()
        {
           var movieslist = _movieContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

           return View(movieslist);
        }

        //Controllers for Editing a movie
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            var movie = _movieContext.Movies.Single(x => x.MovieID == movieid);

            return View("Movies", movie);
        }

        [HttpPost]
        public IActionResult Edit(AddMovie um)
        {
            _movieContext.Update(um);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieDatabase");
        }

        //Controllers for Deleting a movie
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = _movieContext.Movies.Single(x => x.MovieID == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(AddMovie dm)
        {
            _movieContext.Movies.Remove(dm);
            _movieContext.SaveChanges();


            return RedirectToAction("MovieDatabase");
        }

        //Extra Stuff
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
}
