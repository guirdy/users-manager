using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UsersManagerApi.Data.Dtos.AddressDtos;
using UsersManagerApi.Data.Dtos.ContactDtos;
using UsersManagerApi.Data.SwaggerContracts;
using UsersManagerApi.Services;

namespace UsersManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly ContactServices _contactServices;
        public ContactController(ContactServices contactServices)
        {
            _contactServices = contactServices;
        }
        
        [HttpGet("contacts/{physicalPersonId}")]
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

        [HttpGet("contact/{contactId}", Name = "GetContactById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContactContract))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetContactById([FromRoute] string contactId)
        {
            if (!Guid.TryParse(contactId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            GetContactDto contact = _contactServices.GetContactById(parseId);

            if (contact == null)
            {
                return NotFound("Contato não encontrado.");
            }

            return Ok(contact);
        }

        [HttpPost("contact")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ContactContract))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateContact([FromBody] CreateContactDto contactDto)
        {
            GetContactDto contact = _contactServices.CreateContact(contactDto);

            return CreatedAtRoute("GetContactById", new { contactId = contact.Id }, contact);
        }

        /// <remarks>
        ///     <summary>
        ///         Somente "op", "path" e "value são obrigatórios.
        ///     </summary>
        ///     <summary>
        ///         "op" é a operação de patch, deve ser utilizado o valor "replace".
        ///     </summary>
        ///     <summary>
        ///         "path" é o nome do atributo a ser atualizado.
        ///     </summary>
        ///     <summary>
        ///         "value" o novo valor atualizado do atributo.
        ///     </summary>
        /// </remarks>
        [HttpPatch("contact/{contactId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateContact(
            string contactId,
            [FromBody] JsonPatchDocument<UpdateContactDto> patch)
        {
            if (!Guid.TryParse(contactId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            GetContactDto? contact = _contactServices.GetContactById(parseId);

            if (contact == null)
            {
                return NotFound("Contato não encontrado.");
            }

            _contactServices.UpdateContact(contact, patch, ModelState);

            return Ok();
        }

        [HttpDelete("contact/{contactId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteContact(string contactId)
        {
            if (!Guid.TryParse(contactId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            GetContactDto? contact = _contactServices.GetContactById(parseId);

            if (contact == null)
            {
                return BadRequest("Contato não encontrado.");
            }

            _contactServices.DeleteContact(contact);

            return Ok();
        }
    }
}
