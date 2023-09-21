
using DMD.Domain.Models;
using MediatR;

namespace DMD.Domain.Queries
{
    public class GetAllBandsRequest : IRequest<List<Band>>
    {
        public GetAllBandsRequest()
        {

        }

        // validators go here
    }
}
