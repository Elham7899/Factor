using MediatR;

namespace Application.Cqrs.Queries;

public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : class, IQuery<TResult>
{
}
