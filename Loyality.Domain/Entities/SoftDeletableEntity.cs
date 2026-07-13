using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Domain.Entities
{
    public class SoftDeletableEntity : AuditableEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
    public interface ITenantScoped
    {
         Guid  TenantId{ get; set; }
    }
}
