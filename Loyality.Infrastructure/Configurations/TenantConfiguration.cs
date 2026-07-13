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
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.Property(x => x.Code).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.Code).IsUnique();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.HasData(new Tenant
            {
                Id = SeedTenant.TestTenantId,
                Name = "testTenant01",
                Code = "TestTenant",
                
            });
        }
    }
}
