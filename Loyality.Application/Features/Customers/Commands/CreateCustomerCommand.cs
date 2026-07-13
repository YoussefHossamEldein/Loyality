using Loyality.Application.DTOs.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Application.Features.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public CreateCustomerDto  Dto{ get; set; }
        public CreateCustomerCommand(CreateCustomerDto dto)
        {
            Dto = dto;
        }
    }
}
