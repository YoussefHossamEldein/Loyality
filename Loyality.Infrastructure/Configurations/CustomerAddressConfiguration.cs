using Loyality.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Infrastructure.Configurations
{
    public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.Property(x => x.City).HasMaxLength(20);
            builder.Property(x => x.Country).HasMaxLength(20);
            builder.Property(x => x.PostalCode).HasMaxLength(20);
            builder.Property(x => x.Address).HasMaxLength(100);
            builder.HasQueryFilter(a => !a.IsDeleted);
            builder.HasOne<Tenant>()
                  .WithMany()
                  .HasForeignKey(x => x.TenantId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
