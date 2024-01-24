using AutoMapper;
using UsersManagerApi.Data.Dtos.PhysicalPersonDtos;
using UsersManagerApi.Model;

namespace UsersManagerApi.Profiles
{
    public class PhysicalPersonProfile : Profile
    {
        public PhysicalPersonProfile()
        {
            CreateMap<CreatePhysicalPersonDto, PhysicalPerson>();
            CreateMap<PhysicalPerson, GetPhysicalPersonDto>();
            CreateMap<UpdatePhysicalPersonDto, PhysicalPerson>();
            CreateMap<PhysicalPerson, UpdatePhysicalPersonDto>();
        }
    }
}
