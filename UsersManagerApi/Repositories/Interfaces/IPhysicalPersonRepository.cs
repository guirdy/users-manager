using UsersManagerApi.Model;

namespace UsersManagerApi.Repositories.Interfaces
{
    public interface IPhysicalPersonRepository
    {
        List<PhysicalPerson> GetAllPhysicalPersons(Guid userId);
        PhysicalPerson GetPhysicalPersonById(Guid id);
        PhysicalPerson CreatePhysicalPerson(PhysicalPerson physicalPerson);
        PhysicalPerson UpdatePhysicalPerson(PhysicalPerson physicalPerson);
        void DeletePhysicalPerson(Guid id);
    }
}
