using MapsterMapper;
using MediatR;

namespace Application.Shared.Behaviours;

internal class MappingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IMapper Mapper;

    public MappingBehaviour(IMapper mapper)
    {
        Mapper = mapper;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();

        return Mapper.Map<TResponse>(response);
    }
}
