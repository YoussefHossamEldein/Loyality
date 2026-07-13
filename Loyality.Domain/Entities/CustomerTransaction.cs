using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Domain.Entities
{
    public class CustomerTransaction : AuditableEntity , ITenantScoped
    {
        public Guid TenantId { get; set; }
        public Guid CustomerId { get; set; }
        public int points { get; set; }
        public string? Reference { get; set; }
        public string? Description { get; set; }
        public TransactionType Type{ get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        //Customer - Transaction Relationship

        public Customer Customer { get; set; }
        
    }
}
