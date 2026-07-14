using Loyality.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Loyality.Application.DTOs.Transactions
{
    public class AddTransactionDto
    {
        public Guid CustomerId { get; set; }
        public int Points { get; set; }
        public TransactionType Type { get; set; }
        public string? Reference { get; set; }
        public string? Description { get; set; }
    }
}
