using DMD.Domain.Validation;
using FluentValidation;
using FluentValidation.Results;

namespace DMD.Domain.Requests
{
    public sealed partial class CreateBandRequest : IValidatableRequest
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
