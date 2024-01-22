using System.ComponentModel.DataAnnotations;
using UsersManagerApi.Model;

namespace UsersManagerApi.Data.Dtos.User
{
    public class GetUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<PhysicalPerson>? PhysicalPerson { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
