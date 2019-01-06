using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouCell.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace HouCell.Controllers
{
    [Route("api/uporabnik")]
    public class UporabnikController : Controller
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public UporabnikController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllUporabnik()
        {
            try
            {
                var owners = _repository.Uporabnik.GetAllUporabnik();

                _logger.LogInfo($"Returned all uporabniki from database.");

                return Ok(owners);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUporabniki action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOwnerById(int id)
        {
            try
            {
                var owner = _repository.Uporabnik.GetUporabnikById(id);

                if (owner.UserId.Equals(Guid.Empty))
                {
                    _logger.LogError($"Uporabnik with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned uporabnik with id: {id}");
                    return Ok(owner);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUporabnikById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

       
    }
}
