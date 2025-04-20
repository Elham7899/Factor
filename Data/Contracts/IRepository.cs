using System.Linq.Expressions;
using Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Data.Contracts;
public interface IRepository<TEntity> where TEntity : class, IEntity
{
    DbSet<TEntity> Entities { get; }
    IQueryable<TEntity> Table { get; }
    IQueryable<TEntity> TableNoTracking { get; }

    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
}
