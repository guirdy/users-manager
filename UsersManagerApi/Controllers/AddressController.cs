using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UsersManagerApi.Data.Dtos.AddressDtos;
using UsersManagerApi.Data.Dtos.PhysicalPersonDtos;
using UsersManagerApi.Data.SwaggerContracts;
using UsersManagerApi.Model;
using UsersManagerApi.Repositories.Interfaces;
using UsersManagerApi.Services;

namespace UsersManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly AddressServices _service;

        public AddressController(AddressServices service)
        {
            _service = service;
        }

        [HttpGet("addresses/{physicalPersonId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AddressContract>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllAddresses(string physicalPersonId)
        {
            if (!Guid.TryParse(physicalPersonId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            List<GetAddressDto> addresses = _service.GetAllAddresses(parseId);

            if (addresses == null)
            {
                return NotFound("Endereços não encontrados.");
            }

            return Ok(addresses);
        }

        [HttpGet("address/{addressId}", Name = "GetAddressById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressContract))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAddressById(string addressId)
        {
            if (!Guid.TryParse(addressId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            GetAddressDto address = _service.GetAddressById(parseId);

            if (address == null)
            {
                return NotFound("Endereço não encontrado.");
            }

            return Ok(address);
        }

        [HttpPost("address")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult CreateAddress([FromBody] CreateAddressDto addressDto)
        {
            GetAddressDto createdAddress = _service.CreateAddress(addressDto);

            return CreatedAtAction("GetAddressById", new { addressId = createdAddress.Id }, createdAddress);
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
        [HttpPatch("address/{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateAddress(
            string addressId,
            [FromBody] JsonPatchDocument<UpdateAddressDto> patch)
        {
            if (!Guid.TryParse(addressId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            GetAddressDto? address = _service.GetAddressById(parseId);

            if (address == null)
            {
                return NotFound("Endereço não encontrado.");
            }

            _service.UpdateAddress(address, patch, ModelState);

            return Ok();
        }

        [HttpDelete("address/{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteAddress(string addressId)
        {
            if (!Guid.TryParse(addressId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            GetAddressDto? address = _service.GetAddressById(parseId);

            if (address == null)
            {
                return BadRequest("Endereço não encontrado.");
            }

            _service.DeleteAddress(address);

            return Ok();
        }
    }
}
