using DevQuestions.Application.Exceptions;
using DevQuestions.Domain.Questions;
using Shared;

namespace DevQuestions.Application.Questions.Fails.Exceptions
{
    public class QuestionNotFoundException : NotFoundException
    {
        public QuestionNotFoundException(IEnumerable<Error> errors)
            : base(errors)
        {
        }
    }
}