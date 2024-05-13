using DMD.Data.Models;
using DMD.Domain.Requests;
using DMD.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;
using System.Net;

namespace DMD.Web.Controllers
{
    [ApiController]
    [Route("api/bands")]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
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
        [ProducesResponseType(typeof(IEnumerable<Band>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<DbBand>> GetAllBandsAsync()
        {
            _logger.LogInformation("Called bands/getAllBands");
            return await _mediator.Send(new GetAllBandsRequest());
        }

        [HttpPost("/createBand")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task CreateBandAsync([FromBody] CreateBandRequest request)
        {
            _logger.LogInformation("Called bands/createBand");
            await _mediator.Send(request);
        }
    }
}