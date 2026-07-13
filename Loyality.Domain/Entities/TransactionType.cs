using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Domain.Entities
{
    public enum TransactionType
    {
        Earn=1,
        Redeem,
        Adjustment,
        Reversal,
        Expiry
    }
}
