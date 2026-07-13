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
    public class CustomerTierHistoryConfiguration : IEntityTypeConfiguration<CustomerTierHistory>
    {
        public void Configure(EntityTypeBuilder<CustomerTierHistory> builder)
        {

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.EntryReason).HasConversion<string>().HasMaxLength(30);
            builder.Property(x => x.ExitReason).HasConversion<string>().HasMaxLength(30);
            builder.HasIndex(x => new { x.CustomerId, x.EndDate });
            builder.HasOne(x => x.Tier).WithMany(t => t.History).HasForeignKey(x => x.TierId).OnDelete(deleteBehavior:DeleteBehavior.Restrict);
        }
    }
}
