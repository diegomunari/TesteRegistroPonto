using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Domain.Interfaces;
using Teste.Domain.Models;
using Teste.Infra.Context;

namespace Teste.Infra.Repositories
{
    public class Repository <TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            var query = _context.Set<TEntity>().Where(x => x.Id == id);

            if (query.Any())
            {
                return query.FirstOrDefault();
            }

            return null;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var query = _context.Set<TEntity>();

            if (query.Any())
            {
                return query.ToList();
            }

            return new List<TEntity>();
        }

        public virtual async Task<string> Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);

            await SaveChangesAsync();
            return "success";
        }

        public async Task<int> SaveChangesAsync()
        {
            var response = 0;
            using (var transaction = _context.Database.BeginTransaction())
            {
                response = await _context.SaveChangesAsync();
                transaction.Commit();
            }

            return response;
        }
    }
}
