using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UsersManagerApi.Data.Dtos.AddressDtos;
using UsersManagerApi.Data.Dtos.PhysicalPersonDtos;
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
            Address address = _mapper.Map<Address>(addressDto);
            address = _repository.CreateAddress(address);
            return _mapper.Map<GetAddressDto>(address);
        }

        public void UpdateAddress(
            GetAddressDto addressDto,
            JsonPatchDocument<UpdateAddressDto> patch,
            ModelStateDictionary modelState)
        {
            Address originalAddress = _repository.GetAddressById(addressDto.Id);
            UpdateAddressDto addressToUpdate = _mapper.Map<UpdateAddressDto>(originalAddress);

            patch.ApplyTo(addressToUpdate, modelState);

            if (!modelState.IsValid)
            {
                throw new Exception("Ocorreu um erro ao atualizar endereço.");
            }

            _mapper.Map(addressToUpdate, originalAddress);
            _repository.UpdateAddress();
        }

        public void DeleteAddress(GetAddressDto address)
        {
            Address originalAddress = _repository.GetAddressById(address.Id);
            _repository.DeleteAddress(originalAddress);
        }
    }
}
