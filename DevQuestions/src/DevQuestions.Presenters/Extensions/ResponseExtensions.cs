using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace DevQuestions.Presenters.Extensions
{
    public static class ResponseExtensions
    {
        public static ActionResult ToErrorResponse(this Error[] errors)
        {
            if (!errors.Any())
            {
                return new ObjectResult(null)
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }

            var distinctErrorTypes = errors.Select(e => e.Type).Distinct();

            int statusCode = distinctErrorTypes.Count() > 1
                ? StatusCodes.Status500InternalServerError
                : GetStatusCodeFromErrorType(distinctErrorTypes.Single());

            return new ObjectResult(errors)
            {
                StatusCode = statusCode,
            };
        }

        private static int GetStatusCodeFromErrorType(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Failure => StatusCodes.Status500InternalServerError,
                _ => StatusCodes.Status500InternalServerError,
            };
    }
}