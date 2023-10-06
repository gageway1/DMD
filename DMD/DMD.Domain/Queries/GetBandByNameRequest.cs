using DMD.Domain.Models;
using MediatR;

namespace DMD.Domain.Queries
{
    public partial class GetBandByNameRequest : IRequest<Band>
    {
        public GetBandByNameRequest(string name)
        {
            Name = name;
        }

        public string Name { get; init; }
    }

}
