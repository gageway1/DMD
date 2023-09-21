using DMD.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DMD.Web.Controllers
{
    [ApiController]
    [Route("api/bands")]
    public class BandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BandController(IMediator meditor)
        {
            _mediator = meditor;
        }

        [HttpGet("/getAllBands")]
        public async Task<List<Domain.Models.Band>> GetAllBandsAsync()
        {
            return await _mediator.Send(new GetAllBandsRequest());
        }
    }
}