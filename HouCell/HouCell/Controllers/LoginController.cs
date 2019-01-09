using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using HouCell.RepositoryInterfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HouCell.Controllers
{
    public class LoginController : Controller
    {
        ILoggerManager _logger;
        IRepositoryWrapper _wrapper;
        public LoginController(ILoggerManager logger, IRepositoryWrapper wrapper)
        {
            _logger = logger;
            _wrapper = wrapper;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            HttpContext.Session.Remove("logID");
            return View();
        }

        [HttpPost]
        public IActionResult Index(string userName, string pass)
        {

            bool success = false;

            
            int logID = _wrapper.Uporabnik.UporabnikExists(userName, pass);
            if (logID != -1)
            {
                HttpContext.Session.SetInt32("logID", (Int32)logID);
                TempData["logID"] = (int)logID;
                success = true;
            }


            if (success)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        


    }
}
