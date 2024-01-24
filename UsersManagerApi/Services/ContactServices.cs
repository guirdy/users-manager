using AutoMapper;
using UsersManagerApi.Data.Dtos.ContactDtos;
using UsersManagerApi.Model;
using UsersManagerApi.Repositories.Interfaces;

namespace UsersManagerApi.Services
{
    public class ContactServices
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public ContactServices(IMapper mapper, IContactRepository repository)
        {
            _mapper = mapper;
            _contactRepository = repository;
        }

        public List<GetContactDto> GetAllContacts(Guid physicalPersonId)
        {
            List<Contact> contacts = _contactRepository.GetAllContacts(physicalPersonId);
            return _mapper.Map<List<GetContactDto>>(contacts);
        }
    }
}
