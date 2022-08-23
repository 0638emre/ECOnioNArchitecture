using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    public class BaseController:ControllerBase
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;
    }
}
