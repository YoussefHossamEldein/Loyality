using Loyality.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Loyality.Infrastructure.Data
{
    public class LoyalityDbContext : DbContext
    {
        public LoyalityDbContext(DbContextOptions<LoyalityDbContext> options) : base(options)
        {
            
        }
        public DbSet<Customer>  Customers{ get; set; }
        public DbSet<Tier> Tiers { get; set; }
        public DbSet<CustomerTierHistory> CustomerTierHistories{ get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerTransaction> Transactions{ get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LoyalityDbContext).Assembly);
        }
    }
}
