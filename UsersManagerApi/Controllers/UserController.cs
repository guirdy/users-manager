using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UsersManagerApi.Data.Dtos.UserDtos;
using UsersManagerApi.Model;
using UsersManagerApi.Services;
using UsersManagerApi.Utils;

namespace UsersManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;
        private readonly PhysicalPersonServices _physicalPersonServices;
        private PwdHash _pwdHash = new PwdHash();

        public UserController(UserServices userServices, PhysicalPersonServices physicalPersonServices)
        {
            _userServices = userServices;
            _physicalPersonServices = physicalPersonServices;
        }

        [HttpGet("{userId}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

            userDto.PhysicalPersons = _physicalPersonServices.GetAllPhysicalPersons(parseId);

            return Ok(userDto);
        }

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

            

            return CreatedAtAction("GetUserById", new { id = user.Id }, user);
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
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUserData(
            [FromRoute] string id,
            [FromBody] JsonPatchDocument<UpdateUserDto> patch)
        {
            if (!Guid.TryParse(id, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            User? user = _context.Users.FirstOrDefault(user => user.Id == parseId);

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var userToUpdate = _mapper.Map<UpdateUserDto>(user);

            patch.ApplyTo(userToUpdate, ModelState);

            if (!TryValidateModel(userToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(userToUpdate, user);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUser ([FromRoute] string id)
        {
            if (!Guid.TryParse(id, out var parseId))
            {
                return BadRequest("ID inválido.");
            }

            User? user = _context.Users.FirstOrDefault(user => user.Id == parseId);

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok();
        }
    }
}
