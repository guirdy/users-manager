﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UsersManagerApi.Enums;

namespace UsersManagerApi.Model
{
    public class Contact
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Nome do contato é obrigatório.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Tipo de contato é obrigatório.")]
        public ContactType Type { get; set; }
        [Required(ErrorMessage = "Contato de email ou telefone é obrigatório.")]
        public string EmailOrPhone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }

        // Relacionamentos
        [Required(ErrorMessage = "É necessário ID da pessoa física relacionada.")]
        [ForeignKey("PhysicalPersonId")]
        public Guid PhysicalPersonId { get; set; }
    }
}
