using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Domain.Interfaces;
using Teste.Domain.Models;
using Teste.Infra.Context;

namespace Teste.Infra.Repositories
{
    public class PontoRepository : Repository<Ponto>, IRepositoryPonto
    {

        public PontoRepository(AppDbContext context) : base(context) { }

        public override async Task<Ponto> GetById(Guid id)
        {
            var query = _context.Set<Ponto>().Where(c => c.Id == id);

            if (query.Any())
            {
                return query.First();
            }

            return null;
        }

        public IEnumerable<Ponto> GetByColaborador(Guid idColaborador)
        {
            var query = _context.Set<Ponto>().Where(c => c.Colaborador.Id == idColaborador);

            return query.Any() ? query.ToList() : new List<Ponto>();
        }

        public IEnumerable<Ponto> GetByData(DateTimeOffset data, bool buscarMesTodo)
        {
            var query = new List<Ponto>();

            if (buscarMesTodo)
                query = _context.Set<Ponto>().Where(c => c.DataHora.Month == data.Month && c.DataHora.Year == data.Year).ToList();
            else
                query = _context.Set<Ponto>().Where(c => c.DataHora.Date == data.Date).ToList();

            return query;
            
        }
        
        public override async Task<IEnumerable<Ponto>> GetAll()
        {
            var query = _context.Set<Ponto>();
            
            return query.Any() ? query.ToList() : new List<Ponto>();
        }

        public override async Task<string> Save(Ponto obj)
        {
            //buscar os registros do dia para validar o novo registro
            var validaPonto = GetByData(obj.DataHora, false);

            //se não tem nenhum registro, indica que é o primeiro, necessitando confirmar somente se é a entrada
            if (validaPonto.Count() == 0 && obj.EntradaSaida == 'S')
            {
                return "Primeiro registro do dia deve ser de Entrada.";
            }

            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;

            return await base.Save(obj);
        }
    }
}
