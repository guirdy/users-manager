using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UsersManagerApi.Data;
using UsersManagerApi.Data.Dtos.User;
using UsersManagerApi.Model;
using UsersManagerApi.Utils;

namespace UsersManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;
        private PwdHash _pwdHash = new PwdHash();

        public UserController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<GetUserDto> GetUsers(
            [FromQuery] int skip = 0,
            [FromQuery] int take = 50)
        {
            var users = _mapper.Map<List<GetUserDto>>(_context.Users.Skip(skip).Take(take).ToArray());

            users.ForEach(user => user.PhysicalPersons = _context.PhysicalPersons.Where(person => person.UserId == user.Id).ToList());

            users.ForEach(user => user.PhysicalPersons.ForEach(
                person => person.Addresses = _context.Addresses.Where(
                    address => address.PhysicalPersonId == person.Id).ToList()));

            users.ForEach(user => user.PhysicalPersons.ForEach(
                person => person.Contacts = _context.Contacts.Where(
                    contact => contact.PhysicalPersonId == person.Id).ToList()));

            return users;
        }

        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserById([FromRoute] string id)
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

            var userDto = _mapper.Map<GetUserDto>(user);

            userDto.PhysicalPersons = _context.PhysicalPersons.Where(person => person.UserId == userDto.Id).ToList();

            userDto.PhysicalPersons.ForEach(
                person => person.Addresses = _context.Addresses.Where(
                    address => address.PhysicalPersonId == person.Id).ToList());

            userDto.PhysicalPersons.ForEach(
                person => person.Contacts = _context.Contacts.Where(
                    contact => contact.PhysicalPersonId == person.Id).ToList());

            return Ok(userDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult CreateUser(
            [FromBody] CreateUserDto userDto)
        {
            var userExists = _context.Users.FirstOrDefault(user => user.Email == userDto.Email);

            if (userExists != null)
            {
                return Conflict("Email já cadastrado.");
            }

            User user = _mapper.Map<User>(userDto);
            user.Password = _pwdHash.HashPassword(user.Password);

            _context.Users.Add(user);
            _context.SaveChanges();

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
