using Loyality.Application.Features.Transactions.Commands;
using Loyality.Application.Interfaces;
using Loyality.Domain.Constants;
using Loyality.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Loyality.Application.Features.Transactions.Handlers
{
    public class AddCustomerTransactionCommandHandler : IRequestHandler<AddCustomerTransactionCommand, AddTransactionResult>
    {
        private readonly IUnitOfWork _unitOfwork;
        public AddCustomerTransactionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }
        public async Task<AddTransactionResult> Handle(AddCustomerTransactionCommand request, CancellationToken cancellationToken)
        {
            //get the tenantId
            var tenantId = SeedTenant.TestTenantId;
            var customer = await _unitOfwork.GetRepository<Customer>().GetByIdAsync(request.Dto.CustomerId, cancellationToken);
            if (customer == null)
                throw new InvalidOperationException("Customer not found");
            //Add New Transaction
            var transaction = new CustomerTransaction
            {
                TenantId = tenantId,
                Customer = customer,
                points = request.Dto.Points,
                Reference = request.Dto.Reference,

                CustomerId = request.Dto.CustomerId,
                Description = request.Dto.Description,
                Type = request.Dto.Type,
                TransactionDate = DateTime.Now
            };
            _unitOfwork.GetRepository<CustomerTransaction>().Add(transaction);
            //Update the cached score 
            customer.CurrentScore += request.Dto.Points;

            //Get Active tiers 
            var activeTiers = await _unitOfwork.GetRepository<Tier>().GetAllAsync();

            var qualifyingTier = activeTiers
                .Where(t => t.TenantId == tenantId && t.IsActive && t.RequiredScore <= customer.CurrentScore)
                .OrderByDescending(t => t.RequiredScore)
                .First(); // the default tier has RequiredScore = 0, so this can never be empty

            var tierChanged = qualifyingTier.Id != customer.CurrentTierId;
            if (tierChanged)
            {
                var activeHistory = await _unitOfwork.GetRepository<CustomerTierHistory>().FirstOrDefaultAsync(
               h => h.CustomerId == customer.Id && h.EndDate == null, tracking: true, ct: cancellationToken);

                if (activeHistory is not null)
                {
                    activeHistory.EndDate = DateTime.Now;
                    activeHistory.ExitReason = qualifyingTier.RequiredScore > activeHistory.Tier.RequiredScore
                        ? TierExitReason.Upgraded
                        : TierExitReason.Downgraded;
                    _unitOfwork.GetRepository<CustomerTierHistory>().Update(activeHistory);
                }

            }


        }
    }
}
