using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Application.Features.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
        }
    }
}
