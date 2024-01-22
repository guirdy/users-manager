using System.ComponentModel.DataAnnotations;

namespace UsersManagerApi.Model
{
    public enum Type
    {
        Phone,
        Email
    }

    public class Contact
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Nome do contato é obrigatório.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Tipo de contato é obrigatório.")]
        public Type Type { get; set; }
        [Required(ErrorMessage = "Contato de email ou telefone é obrigatório.")]
        public string EmailOrPhone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
