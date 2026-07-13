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
    public class TransactionConfiguration : IEntityTypeConfiguration<CustomerTransaction>
    {
        public void Configure(EntityTypeBuilder<CustomerTransaction> builder)
        {
            builder.Property(x => x.Type).HasConversion<string>().HasMaxLength(20);
            builder.Property(x => x.Reference).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.HasOne(x => x.Customer).WithMany(c => c.Transactions).HasForeignKey(x => x.CustomerId);
            builder.HasIndex(x => new { x.CustomerId, x.TransactionDate });
            builder.HasOne<Tenant>()
                   .WithMany()
                   .HasForeignKey(x => x.TenantId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
