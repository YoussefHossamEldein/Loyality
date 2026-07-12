using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Domain.Entities
{
    public class Tier : AuditableEntity
    {
        public Guid TenantId { get; set; }
        public string Name { get; set; } = null!;
        public int RequiredScore { get; set; }    // qualification threshold — must be unique among active tiers per tenant
        public bool IsActive { get; set; } = true;
        public bool IsDefault { get; set; }

        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public ICollection<CustomerTierHistory> History { get; set; } = new List<CustomerTierHistory>();
    }
}
