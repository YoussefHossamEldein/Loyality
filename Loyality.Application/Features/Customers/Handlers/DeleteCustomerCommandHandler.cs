using Loyality.Application.Features.Customers.Commands;
using Loyality.Application.Interfaces;
using Loyality.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Application.Features.Customers.Handlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetCustomerByIdWithTier(request.Id);
            if (customer == null)
                return false;
            _unitOfWork.GetRepository<Customer>().Delete(customer);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }
    }
}
