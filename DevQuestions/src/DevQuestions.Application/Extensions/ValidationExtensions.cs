using FluentValidation.Results;
using Shared;

namespace DevQuestions.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static IEnumerable<Error> ToErrors(this ValidationResult result) =>
            result.Errors.Select(e => Error.Validation(e.ErrorCode, e.ErrorMessage, e.PropertyName));
    }
}