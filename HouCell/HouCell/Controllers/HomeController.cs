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
            //če je TempData["logID"] prazen pomeni da ni bil uspešen login - client nima svojega id-ja
            if(TempData["logID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var entities = new HoucellContext();
            
            return View(entities.Senzorji.ToList());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
