using System.Linq.Expressions;
using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Contracts;
public interface IRepository<TEntity> where TEntity : class, IEntity 
{
    DbSet<TEntity> Entities { get; }
    IQueryable<TEntity> Table { get; }
    IQueryable<TEntity> TableNoTracking { get; }

    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
	Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
}
