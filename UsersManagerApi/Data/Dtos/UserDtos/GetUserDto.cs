using System.Runtime.Serialization;
using UsersManagerApi.Data.Dtos.PhysicalPersonDtos;

namespace UsersManagerApi.Data.Dtos.UserDtos
{
    public class GetUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<GetPhysicalPersonDto>? PhysicalPersons { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
