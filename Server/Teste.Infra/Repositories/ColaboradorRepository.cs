using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Domain.Models;
using Teste.Infra.Context;

namespace Teste.Infra.Repositories
{
    public class ColaboradorRepository : Repository<Colaborador>
    {

        public ColaboradorRepository(AppDbContext context) : base(context) { }

        public override async Task<Colaborador> GetById(Guid id)
        {
            var query = _context.Set<Colaborador>().Where(c => c.Id == id);

            if (query.Any())
            {
                return query.First();
            }

            return null;
        }

        public override async Task<IEnumerable<Colaborador>> GetAll()
        {
            var query = _context.Set<Colaborador>();
            
            return query.Any() ? query.ToList() : new List<Colaborador> ();
        }

        public override async Task<string> Save(Colaborador obj)
        {
            return await base.Save(obj);
        }
    }
}
