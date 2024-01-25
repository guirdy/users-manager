using System.Net;
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

        public Contact? GetContactById(Guid contactId)
        {
            Contact? contact = _context.Contacts.FirstOrDefault(contact => contact.Id == contactId);
            return contact;
        }

        public Contact CreateContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return contact;
        }

        public void UpdateContact()
        {
            _context.SaveChanges();
        }

        public void DeleteContact(Contact contact)
        {
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }
    }
}
