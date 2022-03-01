using System;
using System.ComponentModel.DataAnnotations;
using Teste.Domain.Models;

namespace Teste.Web.DTOs
{
    public class PontoDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Char EntradaSaida { get; set; }  

        [Required]
        public DateTimeOffset DataHora { get; set; }   

        [Required]
        public Colaborador Colaborador { get; set; }
    }
}
