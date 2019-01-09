using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouCell.Models;
using HouCell.RepositoryInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HouCell.Controllers
{
    public class RegisterController : Controller
    {
        int lastUserID;
        int lastHisaID;
        int lastSobaID;
        ILoggerManager _logger;
        IRepositoryWrapper _wrapper;
        public RegisterController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _wrapper = repository;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["invalid"] = false;
            return View();
        }

        [HttpPost]
        public IActionResult Index(string user, string pass, string confirmPass)
        {
            if(pass != confirmPass)
            {
                ViewData["invalid"] = true;
                return View();
            }
            ViewData["invalid"] = false;

            Uporabnik uporabnik = new Uporabnik();
            uporabnik.UserName = user;
            uporabnik.Pass = pass;
            _wrapper.Uporabnik.CreateUporabnik(uporabnik);
            HttpContext.Session.SetInt32("lastID", (Int32)uporabnik.UserId);
            return RedirectToAction("HouseAdd", "Register", lastUserID);

        }

        [HttpGet]
        public IActionResult HouseAdd(int id)
        {
            return View();
        }


        [HttpPost]
        public IActionResult HouseAdd(string naslov, float lat, float lng)
        {
            Hisa hisa = new Hisa();
            hisa.UserId = (int)HttpContext.Session.GetInt32("lastID");
            hisa.Naslov = naslov;
            hisa.Lng = lng;
            hisa.Lat = lat;
            _wrapper.Hisa.CreateHisa(hisa);
            lastHisaID = hisa.HisaId;
            return RedirectToAction("Index", "Login");
        }
    }
}
