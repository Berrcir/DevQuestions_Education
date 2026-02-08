using Shared;

namespace DevQuestions.Application.Questions.Fails
{
    public partial class Errors
    {
        public static class Questions
        {
            public static Error TooManyQuestions() =>
                Error.Failure("question.too.many", "Пользователь не может открыть больше 3х вопросов");

            public static Error NotFound(Guid questionId) =>
                Error.NotFound("question.not.found", $"Вопрос не найден по заданному id - {questionId}");
        }
    }
}