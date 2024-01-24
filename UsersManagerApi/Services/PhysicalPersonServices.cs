using AutoMapper;
using UsersManagerApi.Data.Dtos.PhysicalPersonDtos;
using UsersManagerApi.Model;
using UsersManagerApi.Repositories.Interfaces;

namespace UsersManagerApi.Services
{
    public class PhysicalPersonServices
    {
        private IMapper _mapper;
        private IPhysicalPersonRepository _repository;
        private readonly ContactServices _contactServices;
        private readonly AddressServices _addressServices;

        public PhysicalPersonServices(
            IMapper mapper,
            IPhysicalPersonRepository repository,
            ContactServices contactServices,
            AddressServices addressServices)
        {
            _mapper = mapper;
            _repository = repository;
            _contactServices = contactServices;
            _addressServices = addressServices;
        }

        public List<GetPhysicalPersonDto> GetAllPhysicalPersons(Guid userId)
        {
            var physicalPersons = _mapper.Map<List<GetPhysicalPersonDto>>(_repository.GetAllPhysicalPersons(userId));

            physicalPersons.ForEach(person => person.Addresses = _addressServices.GetAllAddresses(person.Id));

            physicalPersons.ForEach(person => person.Contacts = _contactServices.GetAllContacts(person.Id));

            return physicalPersons;
        }
    }
}
