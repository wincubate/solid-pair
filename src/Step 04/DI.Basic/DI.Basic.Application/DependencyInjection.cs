using DI.Basic.Application.Services.Companies;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Basic.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddScoped<ICompanyService, CompanyService>()
            ;

        return services;
    }
}
