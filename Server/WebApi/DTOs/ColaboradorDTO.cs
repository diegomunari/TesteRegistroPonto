using System;
using System.ComponentModel.DataAnnotations;

namespace Teste.Web.DTOs
{
    public class ColaboradorDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public bool Supervisor { get; set; }
    }
}
