using MediatR;

namespace Application.Shared.Query;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}
