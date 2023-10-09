using DMD.Domain.Validation;
using FluentValidation;
using MediatR;
using System.Text;

namespace DMD.Domain.Middleware
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public async Task<TResponse> Handle(IValidatableRequest<TResponse> request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validationResult = request.Validate();
            var failures = validationResult.Errors.Where(x => x != null).ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }

            return await next();
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            ValidationContext<TRequest> context = new(request);

            Dictionary<string, string[]> errorsDictionary = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .GroupBy(
                    x => x.PropertyName,
                    x => x.ErrorMessage,
                    (propertyName, errorMessages) => new
                    {
                        Key = propertyName,
                        Values = errorMessages.Distinct().ToArray()
                    })
                .ToDictionary(x => x.Key, x => x.Values);

            if (errorsDictionary.Any())
            {
                StringBuilder sb = new();
                sb.AppendLine("Validation errors:");

                foreach (KeyValuePair<string, string[]> error in errorsDictionary)
                {
                    sb.AppendLine($"    {error.Key}:");
                    foreach (string value in error.Value)
                    {
                        sb.AppendLine(value);
                    }
                }

                throw new ValidationException(sb.ToString());
            }

            return await next();
        }
    }
}
