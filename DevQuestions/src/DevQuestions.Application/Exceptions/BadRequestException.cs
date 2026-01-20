using Shared;
using System.Text.Json;

namespace DevQuestions.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        protected BadRequestException(Error error)
            : base(JsonSerializer.Serialize(error))
        {
        }

        protected BadRequestException(IEnumerable<Error> errors)
            : base(JsonSerializer.Serialize(errors))
        {
        }
    }
}