using Loyality.Application.Interfaces;
using Loyality.Domain.Entities;
using Loyality.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly LoyalityDbContext _dbContext;
        public CustomerRepository(LoyalityDbContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomersWithTierAsync(CancellationToken ct = default)
        {

            var customers = _dbContext.Customers.AsNoTracking().Include(c => c.CurrentTier);
            return await customers.ToListAsync(ct);
        }

        public async Task<Customer?> GetCustomerByIdWithTier(Guid id, CancellationToken ct = default)
        {
            var customer = await _dbContext.Customers.Include(c => c.CurrentTier).FirstOrDefaultAsync(c=>c.Id == id);
            if (customer == null)
                return null;
            return customer;
            
        }
    }
}
