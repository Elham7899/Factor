using Data.Contracts;
using Data.Repositories;
using Data;
using Entities.Common;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using Microsoft.EntityFrameworkCore;
using Common;
using Application.Products.Query.GetAll;

namespace Factor;

public static class ServiceCollectionExtensions
{
	public static void AddServices(this IServiceCollection services)
	{

		services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

		var entitiesAssembly = typeof(IEntity).Assembly;
		var dataAssembly = typeof(ApplicationDbContext).Assembly;
		var applicationAssembly = typeof(GetAllProductQueryHandler).Assembly; 

		services.Scan(s =>
			s.FromAssemblies(entitiesAssembly, dataAssembly, applicationAssembly)
				.AddClasses(c => c.AssignableTo(typeof(IScopedDependency)))
				.AsImplementedInterfaces()
				.WithScopedLifetime());

		services.Scan(s =>
		s.FromAssemblies( entitiesAssembly, dataAssembly)
		.AddClasses(c => c.AssignableTo(typeof(ITransientDependency))
		).AsImplementedInterfaces()
		.WithTransientLifetime());

		services.Scan(s =>
		s.FromAssemblies( entitiesAssembly, dataAssembly)
		.AddClasses(c => c.AssignableTo(typeof(ISingletonDependency))
		).AsImplementedInterfaces()
		.WithSingletonLifetime());

	}
}
