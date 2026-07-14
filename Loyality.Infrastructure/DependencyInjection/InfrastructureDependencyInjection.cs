using Loyality.Application.Interfaces;
using Loyality.Infrastructure.Data;
using Loyality.Infrastructure.Repositories;
using Loyality.Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyality.Infrastructure.DependencyInjection
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
                                        IConfiguration configuration)
        {
            services.AddDbContext<LoyalityDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICurrentTenantService, StaticCurrentTenantService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            //services.AddScoped<IMediator, Mediator>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}
