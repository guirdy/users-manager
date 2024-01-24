using AutoMapper;
using UsersManagerApi.Data.Dtos.AddressDtos;
using UsersManagerApi.Model;
using UsersManagerApi.Repositories.Interfaces;

namespace UsersManagerApi.Services
{
    public class AddressServices
    {
        private IMapper _mapper;
        private IAddressRepository _repository;

        public AddressServices(IMapper mapper, IAddressRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public List<GetAddressDto> GetAllAddresses(Guid physicalPersonId)
        {
            var addresses = _mapper.Map<List<GetAddressDto>>(_repository.GetAllAddresses(physicalPersonId));
            return addresses;
        }

        public GetAddressDto GetAddressById(Guid addressId)
        {
            var address = _mapper.Map<GetAddressDto>(_repository.GetAddressById(addressId));
            return address;
        }

        public GetAddressDto CreateAddress(CreateAddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            address = _repository.CreateAddress(address);
            return _mapper.Map<GetAddressDto>(address);
        }

        public GetAddressDto UpdateAddress(UpdateAddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            address = _repository.UpdateAddress(address);
            return _mapper.Map<GetAddressDto>(address);
        }

        public void DeleteAddress(Guid addressId)
        {
            _repository.DeleteAddress(addressId);
        }
    }
}
