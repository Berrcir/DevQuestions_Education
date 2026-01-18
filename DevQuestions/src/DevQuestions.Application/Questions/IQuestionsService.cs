using DevQuestions.Contracts.Questions;

namespace DevQuestions.Application.Questions
{
    public interface IQuestionsService
    {
        Task<Guid> Create(QuestionCreateDto questionDto, CancellationToken cancellationToken);
    }
}