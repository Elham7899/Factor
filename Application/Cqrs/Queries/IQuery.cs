using MediatR;

namespace Application.Cqrs.Queries;
public interface IQuery<TResult> : IRequest<TResult>
{
}
