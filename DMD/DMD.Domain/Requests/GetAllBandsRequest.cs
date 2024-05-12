using DMD.Data.Models;
using DMD.Domain.Validation;
using FluentValidation;
using FluentValidation.Results;

namespace DMD.Domain.Requests
{
    public sealed partial class GetAllBandsRequest : IValidatableRequest<IList<DbBand>>
    {
        public GetAllBandsRequest()
        {

        }

        public ValidationResult Validate() => new Validator().Validate(this);

        public sealed partial class Validator : AbstractValidator<GetAllBandsRequest>
        {
            public Validator()
            {

            }
        }
    }
}
