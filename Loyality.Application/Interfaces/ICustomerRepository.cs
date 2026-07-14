using Loyality.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersWithTierAsync(CancellationToken ct = default);
        Task<Customer?> GetCustomerByIdWithTier(Guid id, CancellationToken ct = default);
     }
}
