﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Flixer.Controllers
{
    public class MovieController : Controller
    {
        [Route("Movies")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
