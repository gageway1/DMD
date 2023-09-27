using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMD.Domain.Queries
{
    internal static class ValidatorExtentions
    {
        public static void Validate(ValidationResult results)
        {
            if (results.IsValid) return;

            StringBuilder sb = new();
            foreach (ValidationFailure failure in results.Errors)
            {
                sb.Append($"\n\nProperty [{failure.PropertyName}] was invalid because of reason [{failure.ErrorMessage}]\n\n");
            }

            throw new ArgumentException(sb.ToString());
        }
    }
}
