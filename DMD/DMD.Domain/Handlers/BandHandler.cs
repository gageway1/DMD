using DMD.Domain.Models;
using DMD.Domain.Queries;
using DMD.Domain.Services;
using MediatR;

namespace DMD.Domain.Handlers
{
    public class BandHandler :
        IRequestHandler<GetAllBandsRequest, List<Band>>,
        IRequestHandler<GetBandByNameRequest, Band>
    {
        private readonly IBandService _bandService;
        public BandHandler(IBandService bandService)
        {
            _bandService = bandService;
        }

        public Task<List<Band>> Handle(GetAllBandsRequest request, CancellationToken cancellationToken)
        {
            return _bandService.GetAllBandsAsync(cancellationToken);
        }

        public Task<Band> Handle(GetBandByNameRequest request, CancellationToken cancellationToken)
        {
            return _bandService.GetBandByNameAsync(request.Name, cancellationToken);
        }
    }
}
