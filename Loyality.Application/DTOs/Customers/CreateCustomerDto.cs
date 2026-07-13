using Loyality.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Application.DTOs.Customers
{
    public class CreateCustomerDto
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender  Gender{ get; set; }
        public string Nationality { get; set; }
        public string PreferredLanguage { get; set; }

    }
}
