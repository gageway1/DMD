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
        [ProducesResponseType(typeof(List<Band>), (int)HttpStatusCode.OK)]
        public async Task<List<Band>> GetAllBandsAsync()
        {
            _logger.LogInformation("Called bands/getAllBands");
            return TinyMapper.Map<List<Data.Models.DbBand>, List<Band>>(await _mediator.Send(new GetAllBandsRequest()));
        }

        [HttpGet("/getBandByName")]
        [ProducesResponseType(typeof(Band), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<Band> GetBandByNameAsync([FromQuery] string name)
        {
            _logger.LogInformation("Called bands/getBandByName");
            return TinyMapper.Map<Data.Models.DbBand, Band>(await _mediator.Send(new GetBandByNameRequest(name)));
        }

        [HttpPost("/createBand")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task CreateBandAsync([FromBody] CreateBandRequest request)
        {
            _logger.LogInformation("Called bands/createBand");
            await _mediator.Send(request);
        }

        [HttpPut("/modifyBand")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task ModifyBandAsync([FromBody] ModifyBandRequest request)
        {
            _logger.LogInformation("Called bands/modifyBand");
            await _mediator.Send(request);
        }
    }
}