using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HouCell.Models;

namespace HouCell.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var entities = new HoucellContext();
            
            return View(entities.Senzorji.ToList());
        }

        public IActionResult About(string test)
        {
            ViewData["Message"] = "Your application description page.";
            ViewData["Test"] = test;
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
}
