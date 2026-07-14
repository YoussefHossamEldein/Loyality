using Loyality.Application.DTOs.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Loyality.Application.Features.Transactions.Commands.AddCustomerTransactionCommand;

namespace Loyality.Application.Features.Transactions.Commands
{
    public class AddCustomerTransactionCommand : IRequest<AddTransactionResult>
    {
        public AddTransactionDto  Dto{ get; set; }
        public AddCustomerTransactionCommand(AddTransactionDto dto)
        {
            Dto = dto;
        }
        public record AddTransactionResult(Guid TransactionId, int NewScore, string CurrentTierName, bool TierChanged);

    }
}
