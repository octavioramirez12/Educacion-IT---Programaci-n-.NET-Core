﻿using Educacion_IT___Programación_.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Educacion_IT___Programación_.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}