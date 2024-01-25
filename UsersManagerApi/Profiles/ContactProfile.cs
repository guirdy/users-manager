using AutoMapper;
using UsersManagerApi.Data.Dtos.ContactDtos;
using UsersManagerApi.Model;

namespace UsersManagerApi.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, GetContactDto>();
            CreateMap<CreateContactDto, Contact>();
            CreateMap<UpdateContactDto, Contact>();
            CreateMap<Contact, UpdateContactDto>();
        }
    }
}
