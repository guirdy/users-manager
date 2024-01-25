using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UsersManagerApi.Data.Dtos.PhysicalPersonDtos;
using UsersManagerApi.Data.Dtos.UserDtos;
using UsersManagerApi.Data.SwaggerContracts;
using UsersManagerApi.Services;

namespace UsersManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class PhysicalPersonController : ControllerBase
    {
        private readonly PhysicalPersonServices _physicalPersonServices;

        public PhysicalPersonController(PhysicalPersonServices physicalPersonServices)
        {
            _physicalPersonServices = physicalPersonServices;
        }

        [HttpGet("physical-persons/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PhysicalPersonContract>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll(string userId)
        {
            if (!Guid.TryParse(userId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            List<GetPhysicalPersonDto> physicalPerson = _physicalPersonServices.GetAllPhysicalPersons(parseId);

            return Ok(physicalPerson);
        }

        [HttpGet("physical-person/{physicalPersonId}", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PhysicalPersonContract))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(string physicalPersonId)
        {
            if (!Guid.TryParse(physicalPersonId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            GetPhysicalPersonDto physicalPerson = _physicalPersonServices.GetPhysicalPersonById(parseId);

            return Ok(physicalPerson);
        }

        [HttpPost("physical-person")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CreatePhysicalPersonDto physicalPersonDto)
        {
            var physicalPersonAlreadyExists = _physicalPersonServices.GetPhysicalPersonByCPF(physicalPersonDto.CPF);

            if (physicalPersonAlreadyExists != null)
            {
                return BadRequest("Já existe uma pessoa física com este CPF.");
            }

            GetPhysicalPersonDto physicalPerson = _physicalPersonServices.CreatePhysicalPerson(physicalPersonDto);

            return CreatedAtAction("GetById", new { physicalPersonId = physicalPerson.Id }, physicalPerson);
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
        [HttpPatch("physical-person/{physicalPersonId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(
            string physicalPersonId,
            [FromBody] JsonPatchDocument<UpdatePhysicalPersonDto> patch)
        {
            if (!Guid.TryParse(physicalPersonId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            GetPhysicalPersonDto? physicalPerson = _physicalPersonServices.GetPhysicalPersonById(parseId);

            if (physicalPerson == null)
            {
                return NotFound("Pessoa física não encontrada.");
            }

            _physicalPersonServices.UpdatePhysicalPerson(physicalPerson, patch, ModelState);

            return Ok();
        }

        [HttpDelete("physical-person/{physicalPersonId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(string physicalPersonId)
        {
            if (!Guid.TryParse(physicalPersonId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            GetPhysicalPersonDto? physicalPerson = _physicalPersonServices.GetPhysicalPersonById(parseId);

            if (physicalPerson == null)
            {
                return BadRequest("Pessoa física não encontrada.");
            }

            _physicalPersonServices.DeletePhysicalPerson(parseId);

            return Ok();
        }
    }
}
