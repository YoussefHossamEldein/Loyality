using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Application.DTOs.Customers
{
    public class CustomerDto
    {
        public Guid CustomerId { get; set; }
        public string LoyaltyMemberId { get; set; }
        
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CurrentTierName { get; set; }
        public int CurrentScore { get; set; }
        public string Status { get; set; }

    }
}
