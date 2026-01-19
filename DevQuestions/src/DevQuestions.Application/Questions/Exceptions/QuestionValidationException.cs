using DevQuestions.Application.Exceptions;

namespace DevQuestions.Application.Questions.Exceptions
{
    public class QuestionValidationException: BadRequestExcepttion
    {
        public QuestionValidationException(string message)
            : base(message)
        {
        }

        public QuestionValidationException(IEnumerable<string> errors)
            : base(errors)
        {
        }
    }
}