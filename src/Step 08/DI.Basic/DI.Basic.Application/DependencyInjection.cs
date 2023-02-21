using DI.Basic.Application.Common.Behaviors;
using DI.Basic.Application.Companies.Commands;
using DI.Basic.Application.Companies.Common;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Basic.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(typeof(DependencyInjection))
            .AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidateBehavior<,>)
             )
            .AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly)
            ;

        return services;
    }
}
