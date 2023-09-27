using DMD.Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Text;

namespace DMD.Domain.Queries
{
    public partial class GetBandByNameRequest : IRequest<Band>
    {
        public GetBandByNameRequest(string name)
        {
            Name = name;
            Validator validator = new();
            ValidatorExtentions.Validate(validator.Validate(this));
        }

        public string Name { get; init; }

        public class Validator : AbstractValidator<GetBandByNameRequest>
        {
            public Validator()
            {
                RuleFor(c => c.Name).NotEmpty().NotNull();
                RuleFor(c => c.Name).NotEqual("failure");
            }
        }
    }

}
