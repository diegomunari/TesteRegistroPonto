using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Domain.Interfaces;

namespace Teste.Domain.Models
{
    public class PontoService
    {
        private readonly IRepositoryPonto _pontoRepository;

        public PontoService(IRepositoryPonto pontoRepository)
        {
            _pontoRepository = pontoRepository;
        }

        public void Save(Ponto ponto)
        {
            _pontoRepository.Save(ponto);
        }

    }
}
