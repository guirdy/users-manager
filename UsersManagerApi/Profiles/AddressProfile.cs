using AutoMapper;
using UsersManagerApi.Data.Dtos.AddressDtos;
using UsersManagerApi.Model;

namespace UsersManagerApi.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, GetAddressDto>();
            CreateMap<CreateAddressDto, Address>();
            CreateMap<UpdateAddressDto, Address>();
            CreateMap<Address, UpdateAddressDto>();
        }
    }
}
