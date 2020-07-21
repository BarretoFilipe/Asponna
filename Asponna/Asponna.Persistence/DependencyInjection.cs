using Asponna.Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Asponna.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AsponnaContext>(options =>
                {
                    options.UseSqlServer(configuration["ConnectionString"],
                        sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(15), errorNumbersToAdd: null);
                        });
                },
                ServiceLifetime.Scoped
                );

            services.AddRepositories();

            return services;
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            var repositoryInterfaces = typeof(IRepository<>).Assembly.GetTypes()
                .Where(type => type.GetInterfaces().Any(@interface => @interface.IsGenericType && @interface.Name == typeof(IRepository<>).Name))
                .ToList();

            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var repositoryInterface in repositoryInterfaces)
            {
                var repositoryImplementation = types.Where(type => repositoryInterface.IsAssignableFrom(type)).SingleOrDefault();
                if (repositoryImplementation != null)
                {
                    services.AddScoped(repositoryInterface, repositoryImplementation);
                }
            }
        }
    }
}