using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class User
    {
        public User()
        {
            Nome = "Teste";
            Email = "aa";
            Senha = "12345";
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 6)]
        public string Senha { get; set; }

        public DateTime DataDeCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataDeAtualizacao { get; set; }

 
    }
}
