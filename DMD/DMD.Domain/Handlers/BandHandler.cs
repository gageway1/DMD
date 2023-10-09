using DMD.Data.Models;
using DMD.Domain.Requests;
using DMD.Domain.Services;
using FluentAssertions;
using MediatR;
using Nelibur.ObjectMapper;

namespace DMD.Domain.Handlers
{
    internal sealed class BandHandler :
        IRequestHandler<GetAllBandsRequest, List<DbBand>>,
        IRequestHandler<GetBandByNameRequest, DbBand>,
        IRequestHandler<CreateBandRequest, DbBand>,
        IRequestHandler<ModifyBandRequest, DbBand>
    {
        private readonly IBandService _bandService;
        public BandHandler(IBandService bandService)
        {
            _bandService = bandService;
        }

        public Task<List<DbBand>> Handle(GetAllBandsRequest request, CancellationToken cancellationToken)
        {
            return _bandService.GetAllBandsAsync(cancellationToken);
        }

        public Task<DbBand> Handle(GetBandByNameRequest request, CancellationToken cancellationToken)
        {
            return _bandService.GetBandByNameAsync(request.Name, cancellationToken);
        }

        public Task<DbBand> Handle(CreateBandRequest request, CancellationToken cancellationToken)
        {

            return _bandService.CreateBandAsync(request.Name, request.Genre, cancellationToken);
        }

        public Task<DbBand> Handle(ModifyBandRequest request, CancellationToken cancellationToken)
        {
            return _bandService.ModifyBandAsync(request.Id, request.Name, request.Genre, request.ModifiedBy, cancellationToken);
        }
    }
}
