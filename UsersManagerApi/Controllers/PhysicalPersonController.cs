using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsersManagerApi.Data;
using UsersManagerApi.Model;
using UsersManagerApi.Services;

namespace UsersManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1/physical-persons")]
    public class PhysicalPersonController : ControllerBase
    {
        private readonly PhysicalPersonServices _physicalPersonServices;

        public PhysicalPersonController(PhysicalPersonServices physicalPersonServices)
        {
            _physicalPersonServices = physicalPersonServices;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll(string userId)
        {
            if (!Guid.TryParse(userId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            var physicalPerson = _physicalPersonServices.GetAllPhysicalPersons(parseId);

            return Ok(physicalPerson);
        }
    }
}
