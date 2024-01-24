using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UsersManagerApi.Data.Dtos.AddressDtos
{
    public class CreateAddressDto
    {
        [Required(ErrorMessage = "Logradouro é obrigatório.")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Número é obrigatório.")]
        public string Number { get; set; }
        [Required(ErrorMessage = "CEP é obrigatório.")]
        public string PostalCode { get; set; }
        public string? Complement { get; set; }
        [Required(ErrorMessage = "Cidade é obrigatória.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Estado é obrigatório.")]
        public string State { get; set; }

        // Relacionamentos
        [Required(ErrorMessage = "É necessário ID da pessoa física relacionada.")]
        [ForeignKey("PhysicalPersonId")]
        public Guid PhysicalPersonId { get; set; }
    }
}
