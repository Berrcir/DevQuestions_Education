using DevQuestions.Application.Exceptions;
using DevQuestions.Domain.Questions;

namespace DevQuestions.Application.Questions.Exceptions
{
    public class QuestionNotFoundException: NotFoundException<Question>
    {
        public QuestionNotFoundException(Guid id)
            : base(id)
        {

        }
    }
}