using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Domain.Entities
{
    public enum TierExitReason
    {
        Upgraded=1,
        Downgraded,
        ManualOverride,
        Expired,
        AccountClosed
    }
}
