using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("KodlamaDevsConnectionString")));

            services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
            services.AddScoped<IProgrammingLanguageTechnologyRepository, ProgrammingLanguageTechnologyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGithubProfileRepository, GithubProfileRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

            return services;
        }
    }
}
