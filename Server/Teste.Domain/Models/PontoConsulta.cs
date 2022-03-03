using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Domain.Models
{
    public class PontoConsulta
    {
        public DateTimeOffset Data { get; set; }
        public Colaborador Colaborador { get; set; }
        public bool BuscaMesTodo { get; set; }
    }
    
}
