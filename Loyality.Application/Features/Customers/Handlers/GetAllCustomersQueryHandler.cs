using Loyality.Application.DTOs.Customers;
using Loyality.Application.Features.Customers.Queries;
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
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllCustomersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }
        public async Task<List<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllCustomersWithTierAsync(cancellationToken);
            var mappedCustomers = customers.Select(c => new CustomerDto
            {
                Status = c.Status.ToString(),
                CurrentScore = c.CurrentScore,
                CurrentTierName = c.CurrentTier.Name,
                Email = c.Email,
                LoyaltyMemberId = c.LoyaltyMemberId,
                PhoneNumber = c.PhoneNumber,
                FullName = c.FullName,
                CustomerId = c.Id
            }).ToList();
            return mappedCustomers;
        }
    }
}
