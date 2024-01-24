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

        public PhysicalPerson GetPhysicalPersonById(Guid id)
        {
            PhysicalPerson physicalPerson = _context.PhysicalPersons.FirstOrDefault(person => person.Id == id);
            return physicalPerson;
        }

        public PhysicalPerson CreatePhysicalPerson(PhysicalPerson physicalPerson)
        {
            _context.PhysicalPersons.Add(physicalPerson);
            _context.SaveChanges();

            return physicalPerson;
        }

        public PhysicalPerson UpdatePhysicalPerson(PhysicalPerson physicalPerson)
        {
            _context.PhysicalPersons.Update(physicalPerson);
            _context.SaveChanges();

            return physicalPerson;
        }

        public void DeletePhysicalPerson(Guid id)
        {
            var physicalPerson = _context.PhysicalPersons.FirstOrDefault(person => person.Id == id);

            if (physicalPerson != null)
            {
                _context.PhysicalPersons.Remove(physicalPerson);
                _context.SaveChanges();
            }
        }   
    }
}
