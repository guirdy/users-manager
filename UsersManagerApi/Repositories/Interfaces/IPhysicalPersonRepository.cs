using UsersManagerApi.Data.Dtos.PhysicalPersonDtos;
using UsersManagerApi.Model;

namespace UsersManagerApi.Repositories.Interfaces
{
    public interface IPhysicalPersonRepository
    {
        List<PhysicalPerson> GetAllPhysicalPersons(Guid userId);
        PhysicalPerson GetPhysicalPersonById(Guid id);
        PhysicalPerson GetPhysicalPersonByCPF(string cpf);
        PhysicalPerson CreatePhysicalPerson(PhysicalPerson physicalPerson);
        void UpdatePhysicalPerson();
        void DeletePhysicalPerson(PhysicalPerson physicalPerson);
    }
}
