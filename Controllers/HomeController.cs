using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Flixer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Str1"] = "This is a website created by Johannes Nilsson as a part of a university course called \"ASP.NET med C#\".";
            ViewBag.Str2 = "It's built with the purpose of learning ASP.NET Core MVC.";
            return View();
        }
    }
}
