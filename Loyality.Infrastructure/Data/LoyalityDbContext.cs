using Loyality.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Infrastructure.Data
{
    public class LoyalityDbContext : DbContext
    {
        public LoyalityDbContext(DbContextOptions<LoyalityDbContext> options) : base(options)
        {
            
        }
        public DbSet<Customer>  Customers{ get; set; }
        public DbSet<Tier> Tiers { get; set; }
        public DbSet<CustomerTierHistory> CustomerTierHistory{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LoyalityDbContext).Assembly);
        }
    }
}
