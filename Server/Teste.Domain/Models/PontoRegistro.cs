using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Domain.Models
{
    public class PontoRegistro
    {
        public string Data { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSaida { get; set; }
        public string HorasTrabalhadas { get; set; }
        public string HorasTrabalhadasTotal { get; set; }
        public Colaborador colaborador { get; set; }

    }
}
