using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UsersManagerApi.Data.Dtos.PhysicalPersonDtos;
using UsersManagerApi.Data.Dtos.UserDtos;
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

        public GetPhysicalPersonDto? GetPhysicalPersonById(Guid id)
        {
            GetPhysicalPersonDto physicalPerson = _mapper.Map<GetPhysicalPersonDto>(_repository.GetPhysicalPersonById(id));

            if (physicalPerson == null)
            {
                return null;
            }

            physicalPerson.Addresses = _addressServices.GetAllAddresses(physicalPerson.Id);

            physicalPerson.Contacts = _contactServices.GetAllContacts(physicalPerson.Id);

            return physicalPerson;
        }

        public GetPhysicalPersonDto? GetPhysicalPersonByCPF(string cpf)
        {
            GetPhysicalPersonDto? physicalPerson = _mapper.Map<GetPhysicalPersonDto>(_repository.GetPhysicalPersonByCPF(cpf));

            if (physicalPerson == null)
            {
                return null;
            }

            physicalPerson.Addresses = _addressServices.GetAllAddresses(physicalPerson.Id);

            physicalPerson.Contacts = _contactServices.GetAllContacts(physicalPerson.Id);

            return physicalPerson;
        }

        public GetPhysicalPersonDto CreatePhysicalPerson(CreatePhysicalPersonDto physicalPersonDto)
        {
            var physicalPerson = _mapper.Map<PhysicalPerson>(physicalPersonDto);

            PhysicalPerson createdPhysicalPerson = _repository.CreatePhysicalPerson(physicalPerson);

            return _mapper.Map<GetPhysicalPersonDto>(createdPhysicalPerson);
        }

        public void UpdatePhysicalPerson(
            GetPhysicalPersonDto physicalPersonDto,
            JsonPatchDocument<UpdatePhysicalPersonDto> patch,
            ModelStateDictionary modelState)
        {
            PhysicalPerson originalPhysicalPerson = _repository.GetPhysicalPersonById(physicalPersonDto.Id);
            UpdatePhysicalPersonDto physicalPersonToUpdate = _mapper.Map<UpdatePhysicalPersonDto>(originalPhysicalPerson);
            physicalPersonToUpdate.UpdatedAt = DateTime.Now;

            patch.ApplyTo(physicalPersonToUpdate, modelState);

            if (!modelState.IsValid)
            {
                throw new Exception("Ocorreu um erro ao atualizar pessoa física.");
            }

            _mapper.Map(physicalPersonToUpdate, originalPhysicalPerson);
            _repository.UpdatePhysicalPerson();
        }

        public void DeletePhysicalPerson(Guid physicalPersonId)
        {
            PhysicalPerson? physicalPerson = _repository.GetPhysicalPersonById(physicalPersonId);
            _repository.DeletePhysicalPerson(physicalPerson);
        }
    }
}
