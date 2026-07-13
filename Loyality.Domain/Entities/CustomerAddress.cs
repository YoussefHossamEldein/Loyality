using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Domain.Entities
{
    public class CustomerAddress : SoftDeletableEntity, ITenantScoped
    {
        public Guid TenantId { get; set; }
        public Guid CustomerId { get; set; }

        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? District { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }

        public Customer Customer { get; set; } = null!;
    }
}
