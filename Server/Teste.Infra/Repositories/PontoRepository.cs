using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Domain.Interfaces;
using Teste.Domain.Models;
using Teste.Infra.Context;
using Microsoft.EntityFrameworkCore;

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

        //public IEnumerable<Ponto> GetByData(DateTimeOffset data, Colaborador colaborador, bool buscarMesTodo)
        public IEnumerable<Ponto> GetByData(PontoConsulta consulta)
        {
            var query = new List<Ponto>();

            if (consulta.BuscaMesTodo)
                query = _context.Set<Ponto>().Where(c => c.DataHora.Month == consulta.Data.Month && c.DataHora.Year == consulta.Data.Year && c.Colaborador.Id == consulta.Colaborador.Id).Include(x => x.Colaborador).ToList();
            else
                query = _context.Set<Ponto>().Where(c => c.DataHora.Date == consulta.Data.Date && c.Colaborador.Id == consulta.Colaborador.Id).Include(x => x.Colaborador).ToList();

            return query;
            
        }
        
        public override async Task<IEnumerable<Ponto>> GetAll()
        {
            var query = _context.Set<Ponto>().Include(x => x.Colaborador);
            
            return query.Any() ? query.ToList() : new List<Ponto>();
        }

        public override async Task<string> Save(Ponto obj)
        {
            //buscar os registros do dia para validar o novo registro
            PontoConsulta consulta = new PontoConsulta
            {
                Data = obj.DataHora,
                BuscaMesTodo = false,
                Colaborador = obj.Colaborador
            };

            //var validaPonto = GetByData(obj.DataHora, false).OrderBy(x => x.DataHora).ToList();
            var validaPonto = GetByData(consulta).OrderBy(x => x.DataHora).ToList();

            //se não tem nenhum registro, indica que é o primeiro, necessitando confirmar somente se é a entrada
            //ou se já tem registros, verifica se tem entrada antes da saída
            if ((validaPonto.Count() == 0 && obj.EntradaSaida == 'S')) //||
                //(validaPonto.Count() == 2 && obj.EntradaSaida == 'S' && validaPonto[1].EntradaSaida == 'S'))
            {
                return "Registre primeiro a entrada.";
            }

            //verifica se já em a entrada e está tentando registrar entrada novamente
            if ((validaPonto.Count() == 1 && obj.EntradaSaida == 'E' && validaPonto[0].EntradaSaida == 'E'))// ||
                //(validaPonto.Count() == 3 && obj.EntradaSaida == 'E' && validaPonto[2].EntradaSaida == 'E'))
            {
                return "A entrada já foi registrada. Registre a saída.";
            }

            if (validaPonto.Count() == 2)
            { 
                return "O registro de ponto desse dia já foi concluído.";
            }

            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;

            return await base.Save(obj);
        }
    }
}
