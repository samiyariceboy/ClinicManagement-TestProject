using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClinicManagement.Common.Utilities
{
    public static class ValidationResultExtentions
    {
        public static string GetValidationResultErrors(this IEnumerable<ValidationResult> validationResults)
        {
            var stringBuilder = new StringBuilder();
            foreach (var validationResult in validationResults)
                stringBuilder.AppendLine(validationResult.ErrorMessage);
            return stringBuilder.ToString();
        }
    }
}
