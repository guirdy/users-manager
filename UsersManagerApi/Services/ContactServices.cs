using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UsersManagerApi.Data.Dtos.AddressDtos;
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

        public GetContactDto GetContactById(Guid contactId)
        {
            var contact = _mapper.Map<GetContactDto>(_contactRepository.GetContactById(contactId));
            return contact;
        }

        public GetContactDto CreateContact(CreateContactDto contactDto)
        {
            Contact contact = _mapper.Map<Contact>(contactDto);
            contact = _contactRepository.CreateContact(contact);
            return _mapper.Map<GetContactDto>(contact);
        }

        public void UpdateContact(
            GetContactDto contactDto,
            JsonPatchDocument<UpdateContactDto> patch,
            ModelStateDictionary modelState)
        {
            Contact originalContact = _contactRepository.GetContactById(contactDto.Id);
            UpdateContactDto contactToUpdate = _mapper.Map<UpdateContactDto>(originalContact);

            patch.ApplyTo(contactToUpdate, modelState);

            if (!modelState.IsValid)
            {
                throw new Exception("Ocorreu um erro ao atualizar contato.");
            }

            _mapper.Map(contactToUpdate, originalContact);
            _contactRepository.UpdateContact();
        }

        public void DeleteContact(GetContactDto contact)
        {
            Contact originalContact = _contactRepository.GetContactById(contact.Id);
            _contactRepository.DeleteContact(originalContact);
        }
    }
}
