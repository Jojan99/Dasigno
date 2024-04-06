using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dasigno.Core.Helpers
{
    public class ValidationMethodHelper
    {
        public static ValidationResult ValidateGreaterToZero(decimal value, ValidationContext context)
        {
            if (value <= decimal.Zero)
            {
                return new ValidationResult(
                    string.Format(Constants.ERROR_VALIDATE_GREATER_TO_ZERO, context.DisplayName),
                    new List<string>() { context.MemberName });
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
