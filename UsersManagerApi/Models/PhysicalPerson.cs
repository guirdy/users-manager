using System.ComponentModel.DataAnnotations;

namespace UsersManagerApi.Model
{
    public class PhysicalPerson
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

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

        // Endereço
        [Required(ErrorMessage = "Ao menos um endereço é obrigatório.")]
        public List<Address> Addresses { get; set; }

        // Contato
        public List<Contact> Contacts { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
