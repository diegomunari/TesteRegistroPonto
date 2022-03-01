using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Domain.Models
{
    public class Ponto : BaseEntity
    {
        public DateTimeOffset DataHora { get; set; }
        public Char EntradaSaida { get; set; }
        public Colaborador Colaborador { get; set; }


    }
}
