using DMD.Data.Models;
using DMD.Domain.Validation;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace DMD.Domain.Requests
{
    public sealed partial class CreateBandRequest : IValidatableRequest<DbBand>
    {
        public CreateBandRequest(string name, string genre)
        {
            Name = name;
            Genre = genre;
        }

        public string Name { get; init; } = string.Empty;
        public string Genre { get; init; } = string.Empty;

        public ValidationResult Validate() => new Validator().Validate(this);

        public sealed partial class Validator : AbstractValidator<CreateBandRequest>
        {
            public Validator()
            {
                RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
                RuleFor(c => c.Genre).NotEmpty().MaximumLength(100);
            }
        }
    }
}
