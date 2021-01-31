using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flixer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Flixer.Controllers
{
    public class MovieController : Controller
    {
        [Route("Movies")]
        public IActionResult Index()
        {
            // Get the stored movies from the JSON-file
            List<Movie> movies = GetData();

            // Return the view and pass the list to it
            return View(movies);
        }

        [Route("Movie/Details/{id}")]
        public IActionResult SingleMovie(int id)
        {
            // Get the stored movies from the JSON-file
            List<Movie> movies = GetData();

            // Find the movie with the given ID, and pass it to the view
            Movie m = movies.Find(x => x.Id == id);
            return View(m);
        }

        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew([FromForm] Movie m)
        {
            if (ModelState.IsValid)
            {
                // Assign a unique ID for the new movie
                m.Id = FindNextId();

                // Get the stored movies from the JSON-file
                List<Movie> movies = GetData();

                // Add the new movie to the list
                movies.Add(m);

                // Save the new movie to file
                SaveData(movies);

                // Save the new movie in session storage as a serialized JSON-string
                var newMovie = JsonConvert.SerializeObject(m);
                HttpContext.Session.SetString("newMovie", newMovie);

                // Redirect to Created
                return RedirectToAction("Created");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Created()
        {
            // Get the newly added movie from session storage
            string newMovie = HttpContext.Session.GetString("newMovie");

            // Deserialize the JSON and pass the movie object to view via ViewBag
            Movie latestMovie = JsonConvert.DeserializeObject<Movie>(newMovie);
            ViewBag.LatestMovie = latestMovie;

            // Return view
            return View();
        }

        [Route("Movie/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            // Get the stored movies from the JSON-file
            List<Movie> movies = GetData();

            // Find the movie with the given ID, and pass it to the view
            Movie m = movies.Find(x => x.Id == id);

            // Remove the matching movie
            movies.Remove(m);

            // Save updated list of movies to file
            SaveData(movies);

            // Return view
            return View();
        }

        public List<Movie> GetData()
        {
            // Open the JSON-file and read all of its contents
            string json = System.IO.File.ReadAllText("movies.json");

            // Deserialize the JSON and cast as List of Movie objects
            var data = JsonConvert.DeserializeObject<List<Movie>>(json);

            // Return the data
            return data;
        }

        public void SaveData(List<Movie> movies)
        {
            // Serialize the updated data
            var updatedMovies = JsonConvert.SerializeObject(movies);

            // Write the updated data to file
            System.IO.File.WriteAllText("movies.json", updatedMovies);
        }

        public int FindNextId()
        {
            // Get the stored movies from the JSON-file
            List<Movie> movies = GetData();

            // Return the current amount of movies + 1
            return movies.Count() + 1;
        }
    }
}
