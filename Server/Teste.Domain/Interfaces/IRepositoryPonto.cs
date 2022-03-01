using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Models;

namespace Teste.Domain.Interfaces
{
    public interface IRepositoryPonto : IRepository<Ponto>
    {
        IEnumerable<Ponto> GetByColaborador(Guid idColaborador);

        IEnumerable<Ponto> GetByData(DateTimeOffset data, bool buscarMesTodo);
    }
}
