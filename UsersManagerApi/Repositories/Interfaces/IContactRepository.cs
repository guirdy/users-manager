using UsersManagerApi.Model;

namespace UsersManagerApi.Repositories.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetAllContacts(Guid physicalPersonId);
        Contact GetContactById(Guid contactId);
        Contact CreateContact(Contact contact);
        void UpdateContact();
        void DeleteContact(Contact contactId);
    }
}
