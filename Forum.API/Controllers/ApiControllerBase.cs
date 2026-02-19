using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers
{
    public abstract class ApiControllerBase:ControllerBase
    {
        private IMediator? _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();        
    }
}
