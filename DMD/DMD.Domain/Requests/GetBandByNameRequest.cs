﻿using Azure.Core;
using DMD.Data.Models;
using DMD.Domain.Validation;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace DMD.Domain.Requests
{
    public sealed class GetBandByNameRequest : IValidatableRequest<DbBand>
    {
        public GetBandByNameRequest(string name)
        {
            Name = name;
        }

        public string Name { get; init; } = string.Empty;

        public ValidationResult Validate() => new Validator().Validate(this);

        public sealed partial class Validator : AbstractValidator<GetBandByNameRequest>
        {
            public Validator() 
            {
                RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
            }
        }
    }

}
