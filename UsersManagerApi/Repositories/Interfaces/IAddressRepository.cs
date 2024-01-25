using UsersManagerApi.Model;

namespace UsersManagerApi.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        List<Address> GetAllAddresses(Guid physicalPersonId);
        Address GetAddressById(Guid addressId);
        Address CreateAddress(Address address);
        void UpdateAddress();
        void DeleteAddress(Address address);
    }
}
