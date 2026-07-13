using Loyality.Application.Interfaces;
using Loyality.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Infrastructure.Services
{
    public class StaticCurrentTenantService : ICurrentTenantService
    {
        public Guid TenantId => SeedTenant.TestTenantId;

      
    }
}
