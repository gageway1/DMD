using DMD.Domain.Models;
using DMD.Domain.Queries;
using DMD.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMD.Domain.Handlers
{
    public class BandHandler : IRequestHandler<GetAllBandsRequest, List<Band>>
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
    }
}
