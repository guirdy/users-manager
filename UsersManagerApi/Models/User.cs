﻿using System.ComponentModel.DataAnnotations;

namespace UsersManagerApi.Model
{
    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Nome obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome possui muitos caracteres.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Nome de Usuário é obrigatório.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email é obrigatório.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha é obrigatória.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Telefone é obrigatório.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Pessoa física é obrigatória.")]
        [MinLength(1, ErrorMessage = "Deve haver pelo menos uma pessoa física.")]
        public List<PhysicalPerson> PhysicalPersons { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
