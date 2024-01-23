using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsersManagerApi.Data;

namespace UsersManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1/physical-persons")]
    public class PhysicalPersonController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        PhysicalPersonController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetPhysicalPersonById([FromRoute] string id)
        {
            return Ok();
        }
    }
}
