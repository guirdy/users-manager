using UsersManagerApi.Data;
using UsersManagerApi.Model;
using UsersManagerApi.Repositories.Interfaces;

namespace UsersManagerApi.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Address> GetAllAddresses(Guid physicalPersonId)
        {
            List<Address> addresses = _context.Addresses.Where(address => address.PhysicalPersonId == physicalPersonId).ToList();
            return addresses;
        }

        public Address GetAddressById(Guid addressId)
        {
            Address? address = _context.Addresses.FirstOrDefault(address => address.Id == addressId);
            return address;
        }

        public Address CreateAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();

            return address;
        }

        public Address UpdateAddress(Address address)
        {
            _context.Addresses.Update(address);
            _context.SaveChanges();

            return address;
        }

        public void DeleteAddress(Guid addressId)
        {
            var address = _context.Addresses.FirstOrDefault(address => address.Id == addressId);

            if (address != null)
            {
                _context.Addresses.Remove(address);
                _context.SaveChanges();
            }
        }
    }
}
