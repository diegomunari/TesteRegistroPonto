using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Domain.Interfaces;

namespace Teste.Domain.Models
{
    public class ColaboradorService
    {
        private readonly IRepository<Colaborador> _colaboradorRepository;

        public ColaboradorService(IRepository<Colaborador> colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public void Save(Colaborador obj)
        {
            _colaboradorRepository.Save(obj);
            
        }

    }
}
