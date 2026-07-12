using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Domain.Entities
{
    public enum TierEntryReason
    {
        Enrollment = 1,     // initial default tier on signup
        Upgrade = 2,        // qualified upward
        Downgrade = 3,      // dropped from a higher tier into this one
        ManualOverride = 4, // admin set it directly (permission-controlled)
        Renewal = 5         // re-entered same tier at renewal
    }
}
