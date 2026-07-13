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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.NormalizedPhoneNumber).HasMaxLength(20).IsRequired();
            builder.HasIndex(x => new { x.TenantId, x.NormalizedPhoneNumber }).IsUnique();
            builder.Property(x => x.LoyaltyMemberId).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => new { x.TenantId, x.LoyaltyMemberId }).IsUnique();
            builder.Ignore(x => x.FullName);
            builder.Property(x => x.Gender).HasConversion<string>().HasMaxLength(20);
            builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(20);
            builder.HasOne(x => x.Address).WithOne(a => a.Customer).HasForeignKey<CustomerAddress>(a => a.CustomerId);
            builder.HasOne(x => x.CurrentTier).WithMany(x => x.Customers).HasForeignKey(x => x.CurrentTierId);
            builder.HasMany(x => x.TierHistory).WithOne(a => a.Customer).HasForeignKey(a => a.CustomerId)
                     .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<Tenant>()
           .WithMany()
           .HasForeignKey(x => x.TenantId)
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
