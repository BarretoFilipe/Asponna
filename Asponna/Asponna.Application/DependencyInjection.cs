using Asponna.Application.Infrastructure;
using Asponna.Application.Queries.Cards.Get;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Asponna.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetCardQueryHandler).GetTypeInfo().Assembly);

            services.AddValidation();

            return services;
        }

        private static void AddValidation(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidatorBehavior<,>));
        }
    }
}