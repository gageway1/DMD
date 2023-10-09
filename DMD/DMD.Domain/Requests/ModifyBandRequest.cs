using DMD.Data.Models;
using DMD.Domain.Validation;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMD.Domain.Requests
{
    public sealed partial class ModifyBandRequest : IValidatableRequest<DbBand>
    {
        public ModifyBandRequest(Guid id, string name, string genre, string modifiedBy)
        {
            Name = name;
            Genre = genre;
            ModifiedBy = modifiedBy;
            Id = id;
        }
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Genre { get; init; } = string.Empty;
        public string ModifiedBy { get; init; } = string.Empty;

        public ValidationResult Validate() => new Validator().Validate(this);

        public sealed partial class Validator : AbstractValidator<ModifyBandRequest>
        {
            public Validator()
            {
                RuleFor(c => c.Name).NotEmpty();
                RuleFor(c => c.Genre).NotEmpty();
                RuleFor(c => c.ModifiedBy).NotEmpty();
                RuleFor(c => c.Id).NotEmpty();
            }
        }
    }
}
