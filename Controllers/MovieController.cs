using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flixer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Flixer.Controllers
{
    public class MovieController : Controller
    {
        [Route("Movies")]
        public IActionResult Index()
        {
            string moviesJson = GetData();
            ViewData["json"] = moviesJson;
            return View();
        }

        public string GetData()
        {
            string json = System.IO.File.ReadAllText("movies.json");
            return json;
        }
    }
}
