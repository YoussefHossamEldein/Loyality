using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Domain.Entities
{
    public class Tenant : AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
