using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Application.Interfaces
{
    public interface ICurrentTenantService
    {
       public Guid TenantId { get; }
    }
    
}
