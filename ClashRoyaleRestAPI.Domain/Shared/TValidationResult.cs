using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Domain.Shared
{
    public class ValidationResult<TResult> : Result<TResult>, IValidationResult
    {
        private ValidationResult(Error[] errors) : base(default, false, IValidationResult.ValidationError)
        {
            Errors = errors;
        }

        public new Error[] Errors { get;  }

        public static ValidationResult<TResult> Create(Error[] errors)
        {
            return new ValidationResult<TResult>(errors);
        }
    }
}
