using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Domain.Entities
{
    public class CustomerTierHistory : AuditableEntity
    {
        public Guid TenantId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid TierId { get; set; }

        public DateTime StartDate { get; set; }
        public TierEntryReason EntryReason { get; set; }   // why they entered this tier

        public DateTime? EndDate { get; set; }             // null = current/active tier
        public TierExitReason? ExitReason { get; set; }    // why they left (null while active)

        // "Who performed this transition" is captured by AuditableEntity.CreatedById/CreatedByType.

        public Customer Customer { get; set; } = null!;
        public Tier Tier { get; set; } = null!;
    }
}
