using UsersManagerApi.Data;
using UsersManagerApi.Model;
using UsersManagerApi.Repositories.Interfaces;

namespace UsersManagerApi.Repositories
{
    public class PhysicalPersonRepository : IPhysicalPersonRepository
    {
        private readonly AppDbContext _context;

        public PhysicalPersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<PhysicalPerson> GetAllPhysicalPersons(Guid userId)
        {
            List<PhysicalPerson> physicalPersons = _context.PhysicalPersons.Where(person => person.UserId == userId).ToList();
            return physicalPersons;
        }

        public PhysicalPerson? GetPhysicalPersonById(Guid id)
        {
            PhysicalPerson? physicalPerson = _context.PhysicalPersons.FirstOrDefault(person => person.Id == id);
            return physicalPerson;
        }

        public PhysicalPerson? GetPhysicalPersonByCPF(string cpf)
        {
            PhysicalPerson? physicalPerson = _context.PhysicalPersons.FirstOrDefault(person => person.CPF == cpf);
            return physicalPerson;
        }

        public PhysicalPerson CreatePhysicalPerson(PhysicalPerson physicalPerson)
        {
            _context.PhysicalPersons.Add(physicalPerson);
            _context.SaveChanges();

            return physicalPerson;
        }

        public void UpdatePhysicalPerson()
        {
            _context.SaveChanges();
        }

        public void DeletePhysicalPerson(PhysicalPerson physicalPerson)
        {
            _context.PhysicalPersons.Remove(physicalPerson);
            _context.SaveChanges();
        }   
    }
}
