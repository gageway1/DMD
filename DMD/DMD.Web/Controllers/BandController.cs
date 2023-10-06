using DMD.Domain.Queries;
using DMD.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;

namespace DMD.Web.Controllers
{
    [ApiController]
    [Route("api/bands")]
    public class BandController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BandController> _logger;

        public BandController(IMediator meditor, ILogger<BandController> logger)
        {
            _mediator = meditor;
            _logger = logger;
        }

        [HttpGet("/getAllBands")]
        public async Task<List<Band>> GetAllBandsAsync()
        {
            _logger.LogInformation("Called bands/getAllBands");
            return TinyMapper.Map<List<Domain.Models.Band>, List<Band>>(await _mediator.Send(new GetAllBandsRequest()));
        }

        [HttpGet("/getBandByName")]
        public async Task<Band> GetBandByNameAsync([FromQuery] string name)
        {
            _logger.LogInformation("Called bands/getBandByName");
            return TinyMapper.Map<Domain.Models.Band, Band>(await _mediator.Send(new GetBandByNameRequest(name)));
        }
    }
}