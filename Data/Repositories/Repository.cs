using Data.Contracts;
using Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
		where TEntity : class, IEntity
{
	protected readonly ApplicationDbContext DbContext;
	public DbSet<TEntity> Entities { get; }
	public virtual IQueryable<TEntity> Table => Entities;
	public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

	public Repository(ApplicationDbContext dbContext)
	{
		DbContext = dbContext;
		Entities = DbContext.Set<TEntity>(); // City => Cities
	}

	public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
	{
		await Entities.AddAsync(entity, cancellationToken).ConfigureAwait(false);

		await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
	}

	public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
	{
		Entities.Update(entity);
		await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
	}
}
