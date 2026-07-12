using Loyality.Application.Interfaces;
using Loyality.Domain.Entities;
using Loyality.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : AuditableEntity, new()
    {
        private readonly LoyalityDbContext _dbContext;
        public GenericRepository(LoyalityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = false ,CancellationToken ct = default)
        {
            IQueryable<TEntity> query = tracking ? _dbContext.Set<TEntity>() : _dbContext.Set<TEntity>().AsNoTracking();
            return await query.ToListAsync(ct);
        }

        public async Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default) => await _dbContext.Set<TEntity>().FindAsync(id, ct);
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().AnyAsync(predicate, ct);
        }
        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,bool tracking = false, CancellationToken ct = default)
        {
            IQueryable<TEntity> query = tracking ? _dbContext.Set<TEntity>() : _dbContext.Set<TEntity>().AsNoTracking();
            return await query.FirstOrDefaultAsync(predicate, ct);
        }


        public async void Add(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            
          
        }


        public async void Delete(TEntity entity)
        {
           
           
            _dbContext.Set<TEntity>().Remove(entity);
           

        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
