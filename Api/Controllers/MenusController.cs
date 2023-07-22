using Application.Menus.Commands;
using Contracts.Menu;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("hosts/{hostId}/menus")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public MenusController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
        {
            var command = _mapper.Map<CreateMenuCommand>((request, hostId));

            var result = await _mediator.Send(command);

            return Ok(_mapper.Map<MenuResponse>(result));
        }
    }
}