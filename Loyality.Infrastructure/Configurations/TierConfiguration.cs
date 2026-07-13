using Loyality.Domain.Constants;
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
    public class TierConfiguration : IEntityTypeConfiguration<Tier>
    {
        public void Configure(EntityTypeBuilder<Tier> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.HasIndex(x => new { x.TenantId, x.RequiredScore }).IsUnique().HasFilter("[IsActive]=1");
            builder.HasOne<Tenant>()
                  .WithMany()
                  .HasForeignKey(x => x.TenantId)
                  .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(new Tier
            {
                Id = Guid.Parse("aaaaaaaa-0000-0000-0000-000000000001"),
                TenantId = SeedTenant.TestTenantId,
                Name = "Bronze",
                RequiredScore = 0,
                IsActive = true,
                IsDefault = true

            },
            new Tier
            {
                Id = Guid.Parse("aaaaaaaa-0000-0000-0000-000000000002"),
                TenantId = SeedTenant.TestTenantId,
                RequiredScore = 500,
                Name = "Silver",
                IsActive = true,
                IsDefault = false
            },new Tier
            {
                Id = Guid.Parse("aaaaaaaa-0000-0000-0000-000000000003"),
                TenantId = SeedTenant.TestTenantId,
                RequiredScore = 1000,
                Name = "Gold",
                IsActive = true,
                IsDefault = false,
            });
        }
    }
}
