using DevQuestions.Application.Exceptions;
using DevQuestions.Domain.Questions;
using Shared;

namespace DevQuestions.Application.Questions.Fails.Exceptions
{
    public class QuestionNotFoundException : NotFoundException
    {
        public QuestionNotFoundException(Guid id)
            : base([Errors.Questions.NotFound(id)])
        {
        }
    }
}