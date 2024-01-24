using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UsersManagerApi.Enums;

namespace UsersManagerApi.Data.Dtos.ContactDtos
{
    public class UpdateContactDto
    {
        [Required(ErrorMessage = "Nome do contato é obrigatório.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Tipo de contato é obrigatório.")]
        public ContactType Type { get; set; }
        [Required(ErrorMessage = "Contato de email ou telefone é obrigatório.")]
        public string EmailOrPhone { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Relacionamentos
        [Required(ErrorMessage = "É necessário ID da pessoa física relacionada.")]
        [ForeignKey("PhysicalPersonId")]
        public Guid PhysicalPersonId { get; set; }
    }
}
