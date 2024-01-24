using UsersManagerApi.Data;
using UsersManagerApi.Model;
using UsersManagerApi.Repositories.Interfaces;

namespace UsersManagerApi.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Contact> GetAllContacts(Guid physicalPersonId)
        {
            List<Contact> contacts = _context.Contacts.Where(contact => contact.PhysicalPersonId == physicalPersonId).ToList();
            return contacts;
        }

        public Contact GetContactById(Guid contactId)
        {
            throw new NotImplementedException();
        }

        public Contact CreateContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(Guid contactId)
        {
            throw new NotImplementedException();
        }
    }
}
