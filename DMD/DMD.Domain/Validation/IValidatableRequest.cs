using FluentValidation.Results;
using MediatR;

namespace DMD.Domain.Validation
{
    public interface IValidatableRequest<TResponse> : IRequest<TResponse>
    {
        ValidationResult Validate();
    }

    public interface IValidatableRequest : IRequest
    {
        ValidationResult Validate();
    }
}
