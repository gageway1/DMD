using DMD.Data.Models;
using DMD.Domain.Requests;
using DMD.Domain.Services;
using FluentAssertions;
using MediatR;
using Nelibur.ObjectMapper;

namespace DMD.Domain.Handlers
{
    internal sealed class BandHandler :
        IRequestHandler<GetAllBandsRequest, IEnumerable<DbBand>>,
        IRequestHandler<CreateBandRequest>
    {
        private readonly IBandService _bandService;
        public BandHandler(IBandService bandService)
        {
            _bandService = bandService;
        }

        public Task<IEnumerable<DbBand>> Handle(GetAllBandsRequest request, CancellationToken cancellationToken)
        {
            return _bandService.GetAllBandsAsync(cancellationToken);
        }

        public Task Handle(CreateBandRequest request, CancellationToken cancellationToken)
        {
            return _bandService.CreateBandAsync(request.Name, request.Genre, cancellationToken);
        }
    }
}
