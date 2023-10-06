using DMD.Domain.Queries;
using FluentValidation;

namespace DMD.Domain.Validators
{
    public sealed class GetBandByNameRequestValidator : AbstractValidator<GetBandByNameRequest>
    {
        public GetBandByNameRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
