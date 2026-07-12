using Loyality.Application.Interfaces;
using Loyality.Domain.Entities;
using Loyality.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LoyalityDbContext _dbContext;
        private readonly Dictionary<string, object> _repositories = [];
        public UnitOfWork(LoyalityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
      

        public async Task<int> SaveChangesAsync(CancellationToken ct = default) => await _dbContext.SaveChangesAsync(ct);

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : AuditableEntity , new()
        {
            var typeName = typeof(TEntity).Name;
            if (_repositories.TryGetValue(typeName, out object? value))
                return (IGenericRepository<TEntity>)value;
            var repo = new GenericRepository<TEntity>(_dbContext);
            _repositories[typeName] = repo;
            return repo;
        }


    }
}
