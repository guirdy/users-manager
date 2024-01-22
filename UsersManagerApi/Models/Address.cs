using System.ComponentModel.DataAnnotations;

namespace UsersManagerApi.Model
{
    public class Address
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
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
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
