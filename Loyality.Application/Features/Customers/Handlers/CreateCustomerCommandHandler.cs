using Loyality.Application.Features.Customers.Commands;
using Loyality.Application.Interfaces;
using Loyality.Domain.Constants;
using Loyality.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Application.Features.Customers.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly IUnitOfWork _UnitOfWork;
        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var tenantId = SeedTenant.TestTenantId;
            var defaultTier = await _UnitOfWork.GetRepository<Tier>().FirstOrDefaultAsync(t => t.TenantId == tenantId && t.IsDefault && t.IsDefault);
            if (defaultTier == null)
                throw new InvalidOperationException("there is no default tier configured for this tenant");
            var normalizedPhone = $"{request.Dto.CountryCode}{new string(request.Dto.PhoneNumber.Where(char.IsDigit).ToArray())}";

            var phoneExists = await _UnitOfWork.GetRepository<Customer>().AnyAsync(
                c => c.TenantId == tenantId && c.NormalizedPhoneNumber == normalizedPhone, cancellationToken);
            if (phoneExists)
                throw new InvalidOperationException("another customer with the same phone number already exist");
            var customer = new Customer
            {
                CurrentTierId = defaultTier.Id,
                TenantId = tenantId,
                FirstName = request.Dto.FirstName,
                LastName = request.Dto.LastName,
                Email = request.Dto.Email,
                DateOfBirth = DateOnly.FromDateTime(request.Dto.DateOfBirth),
                Gender = request.Dto.Gender,
                PhoneNumber = request.Dto.PhoneNumber,
                NormalizedPhoneNumber = normalizedPhone,
                Nationality = request.Dto.Nationality,
                PreferredLanguage = request.Dto.PreferredLanguage,
                CountryCode = request.Dto.CountryCode,
                EnrollmentDate = DateTime.Now
            };
            var history = new CustomerTierHistory
            {
                EntryReason = TierEntryReason.Enrollment,
                Customer = customer,
                StartDate = customer.EnrollmentDate,
                TenantId = tenantId,
                TierId = customer.CurrentTierId,


            };
            _UnitOfWork.GetRepository<CustomerTierHistory>().Add(history);
            await _UnitOfWork.SaveChangesAsync();
            return customer.Id;
            
           
        }
    }
}
