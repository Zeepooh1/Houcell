using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost]
        public IActionResult Index(string userName, string pass)
        {

            //bool success = false;

            int logID = _wrapper.Uporabnik.UporabnikExists(userName, pass);

            return Ok(logID);

        }

    }
}