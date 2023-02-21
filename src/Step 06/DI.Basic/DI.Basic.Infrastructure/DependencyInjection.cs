using DI.Basic.Application.Common.Interfaces.Persistence;
using DI.Basic.Application.Common.Interfaces.Services;
using DI.Basic.Infrastructure.Persistence;
using DI.Basic.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Basic.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            // Note: This would be AddScoped if based upon DbContext or similar
            .AddSingleton<ICompanyRepository, InMemoryCompanyRepository>()
            .AddSingleton<IDateTimeProvider,DateTimeProvider>()
            ;

        return services;
    }
}
