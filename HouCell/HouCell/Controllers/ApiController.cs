using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouCell.Models;
using HouCell.RepositoryInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouCell.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class ApiController : Controller
    {
        ILoggerManager _logger;
        IRepositoryWrapper _wrapper;
        public ApiController(ILoggerManager logger, IRepositoryWrapper wrapper)
        {
            _logger = logger;
            _wrapper = wrapper;
        }

/*         [HttpPost]
        public IActionResult Index()
        {

            
          
            return Ok(_wrapper.Uporabnik.GetUporabnikById(1));

        }*/
        [HttpGet]
        public IActionResult Index(string userName, string pass)
        {

            int logID = _wrapper.Uporabnik.UporabnikExists(userName, pass);
          
            return Ok("[" +logID + "]");

        }
    }
}