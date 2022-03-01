using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Domain.Models
{
    public class Colaborador : BaseEntity
    {
        public string Nome { get; set; }
        public bool Supervisor { get; set; }
        
    }
}
