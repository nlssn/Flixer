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
            // Retrieve the data from the JSON-file
            string data = GetData();

            // Store the data in session storage for later use
            HttpContext.Session.SetString("movies", data);

            // Deserialize the data and return it with the view
            var movies = JsonConvert.DeserializeObject<List<Movie>>(data);
            return View(movies);
        }

        [Route("Movie/{id}")]
        public IActionResult SingleMovie(int id)
        {
            string data = HttpContext.Session.GetString("movies");
            var movies = JsonConvert.DeserializeObject<List<Movie>>(data);
            Movie m = movies.Find(x => x.Id == id);
            return View(m);
        }

        public string GetData()
        {
            // Open the file and return all of its contents
            string json = System.IO.File.ReadAllText("movies.json");
            return json;
        }
    }
}
