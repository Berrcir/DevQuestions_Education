using DirectoryService.Domain.Questions;

namespace DevQuestions.Application.Questions
{
    public interface IQuestionsRepository
    {
        public Task<Guid> AddAsync(Question question, CancellationToken cancellationToken);

        public Task<Guid> SaveAsync(Question question, CancellationToken cancellationToken);

        public Task<bool> DeleteAsync(Guid questionId, CancellationToken cancellationToken);

        public Task<Question?> GetByIdAsync(Guid questionId, CancellationToken cancellationToken);

        public Task<int> GetOpenUserQuestionsAsync(Guid userId, CancellationToken cancellationToken);
    }
}