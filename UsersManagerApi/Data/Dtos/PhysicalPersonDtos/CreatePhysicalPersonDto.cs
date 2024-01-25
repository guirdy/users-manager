using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UsersManagerApi.Model;
using UsersManagerApi.Data.Dtos.AddressDtos;
using UsersManagerApi.Data.Dtos.ContactDtos;
using Swashbuckle.AspNetCore.Annotations;

namespace UsersManagerApi.Data.Dtos.PhysicalPersonDtos
{
    public class CreatePhysicalPersonDto
    {
        // Dados pessoais
        [Required(ErrorMessage = "Nome de pessoa física é obrigatório.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Sobrenome é obrigatório.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Data de Nascimento é obrigatório.")]
        public string Birthday { get; set; }
        [Required(ErrorMessage = "Email é obrigatório.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "CPF é obrigatório.")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "RG é obrigatório.")]
        public string RG { get; set; }

        // Relacionamentos
        [Required(ErrorMessage = "É necessário ID do usuário relacionado.")]
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        // Endereço
        [Required(ErrorMessage = "Endereço é obrigatório.")]
        [MinLength(1, ErrorMessage = "Deve haver pelo menos um endereço.")]
        public List<CreateAddressDto> Addresses { get; set; }

        // Contato
        [Required(ErrorMessage = "Contato é obrigatório.")]
        [MinLength(1, ErrorMessage = "Deve haver pelo menos um contato.")]
        public List<CreateContactDto> Contacts { get; set; }
    }
}
