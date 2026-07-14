using Loyality.Application.DTOs.Customers;
using Loyality.Application.Features.Customers.Queries;
using Loyality.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Application.Features.Customers.Handlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto?>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCustomerByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetCustomerByIdWithTier(request.Id);
            if (customer == null)
                return null; 
            return new CustomerDto
            {
                Status = customer.Status.ToString(),
                CurrentScore = customer.CurrentScore,
                CustomerId = customer.Id,
                CurrentTierName = customer.CurrentTier.Name,
                FullName = customer.FullName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                LoyaltyMemberId = customer.LoyaltyMemberId
            }

        }
    }
}
