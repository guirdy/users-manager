using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UsersManagerApi.Data.Dtos.UserDtos;
using UsersManagerApi.Data.SwaggerContracts;
using UsersManagerApi.Services;

namespace UsersManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;
        private readonly PhysicalPersonServices _physicalPersonServices;

        public UserController(UserServices userServices, PhysicalPersonServices physicalPersonServices)
        {
            _userServices = userServices;
            _physicalPersonServices = physicalPersonServices;
        }

        [HttpGet("{userId}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserContract))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserById([FromRoute] string userId)
        {
            if (!Guid.TryParse(userId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            GetUserDto? userDto = _userServices.GetUserById(parseId);

            if (userDto == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            return Ok(userDto);
        }

        /// <remarks>
        ///     <summary>
        ///         "physicalPersons" é opcional.
        ///     </summary>
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult CreateUser(
            [FromBody] CreateUserDto userDto)
        {
            GetUserDto? userExists = _userServices.GetUserByEmail(userDto.Email);

            if (userExists != null)
            {
                return Conflict("Email já cadastrado.");
            }

            GetUserDto createdUser = _userServices.CreateUser(userDto);

            return CreatedAtAction("GetUserById", new { userId = createdUser.Id }, createdUser);
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
        [HttpPatch("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUserData(
            [FromRoute] string userId,
            [FromBody] JsonPatchDocument<UpdateUserDto> patch)
        {
            if (!Guid.TryParse(userId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            GetUserDto? user = _userServices.GetUserById(parseId);

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            _userServices.UpdateUser(user, patch, ModelState);

            return Ok();
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUser ([FromRoute] string userId)
        {
            if (!Guid.TryParse(userId, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            GetUserDto? user = _userServices.GetUserById(parseId);

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            _userServices.DeleteUser(parseId);

            return Ok();
        }
    }
}
