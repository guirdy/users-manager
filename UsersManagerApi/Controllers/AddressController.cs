using Microsoft.AspNetCore.Mvc;
using UsersManagerApi.Repositories.Interfaces;

namespace UsersManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1/physical-persons")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _repository;

        public AddressController(IAddressRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{physicalPersonId}/addresses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllAddresses(string physicalPersonId)
        {
            if (!Guid.TryParse(physicalPersonId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            var addresses = _repository.GetAllAddresses(parseId);

            if (addresses == null)
            {
                return NotFound("Endereços não encontrados.");
            }

            return Ok(addresses);
        }
    }
}
