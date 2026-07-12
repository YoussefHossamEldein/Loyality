using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Domain.Entities
{
    public class Customer : AuditableEntity
    {
        public Guid TenantId { get; set; }

        public string LoyaltyMemberId { get; set; } = null!;   // unique, auto-generated
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {LastName}";

        // Phone — raw value as received, plus canonical form for uniqueness/lookup
        public string PhoneNumber { get; set; } = null!;           // immutable; as provided by external source (raw)
        public string CountryCode { get; set; } = null!;
        public string NormalizedPhoneNumber { get; set; } = null!; // unique, immutable; canonical E.164 form
        public string? Email { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string? Nationality { get; set; }
        public string? PreferredLanguage { get; set; }

        public bool IncludeInLoyalty { get; set; } = true;     // exclusion flag
        public CustomerStatus Status { get; set; } = CustomerStatus.Active;

        // Enrollment
        public DateTime EnrollmentDate { get; set; }           // immutable



        // Tier
        public Guid CurrentTierId { get; set; }
        public Tier CurrentTier { get; set; } = null!;
        public ICollection<CustomerTierHistory> TierHistory { get; set; } = new List<CustomerTierHistory>();

        // Owned 1:1 aggregates


        public CustomerAddress? Address { get; set; }

    }
    [Owned]
    public class CustomerAddress
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
