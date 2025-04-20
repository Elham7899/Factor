using Application.Cqrs.Commands;
using Application.Cqrs.Commands.Dispatcher;
using Application.Cqrs.Queries;
using Application.Cqrs.Queries.Dispatcher;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Cqrs;

public static class Extensions
{
    public static IServiceCollection AddCqrs(this IServiceCollection services)
    {
        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssemblies(typeof(ICommand<>).Assembly);
        });
        services.AddValidatorsFromAssembly(typeof(ICommand<>).Assembly);
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();
        return services;
    }
}
