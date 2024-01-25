using Microsoft.AspNetCore.Mvc;
using UsersManagerApi.Data.Dtos.ContactDtos;
using UsersManagerApi.Data.SwaggerContracts;
using UsersManagerApi.Services;

namespace UsersManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1/physical-person")]
    public class ContactController : ControllerBase
    {
        private readonly ContactServices _contactServices;
        public ContactController(ContactServices contactServices)
        {
            _contactServices = contactServices;
        }
        
        [HttpGet("{physicalPersonId}/contacts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ContactContract>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetContacts([FromRoute] string physicalPersonId)
        {
            if (!Guid.TryParse(physicalPersonId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            List<GetContactDto> contacts = _contactServices.GetAllContacts(parseId);

            if (contacts == null)
            {
                return NotFound("Contatos não encontrados.");
            }

            return Ok(contacts);
        }
    }
}
