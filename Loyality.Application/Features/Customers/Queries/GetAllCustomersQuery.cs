using Loyality.Application.DTOs.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Application.Features.Customers.Queries
{
    public class GetAllCustomersQuery : IRequest<List<CustomerDto>>
    {
    }
}
