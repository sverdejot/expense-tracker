using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected readonly ISender _sender;

    protected readonly IMapper _mapper;

    protected ApiController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }
}
