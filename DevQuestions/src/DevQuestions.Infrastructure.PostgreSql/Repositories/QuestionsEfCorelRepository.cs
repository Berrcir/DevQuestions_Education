using DevQuestions.Application.Questions;
using DevQuestions.Domain.Questions;
using Microsoft.EntityFrameworkCore;

namespace DevQuestions.Infrastructure.PostgreSql.Repositories
{
    public class QuestionsEfCorelRepository : IQuestionsRepository
    {
        private readonly QuestionsDbContext _dbContext;

        public QuestionsEfCorelRepository(QuestionsDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Guid> AddAsync(Question question, CancellationToken cancellationToken)
        {
            await _dbContext.Questions.AddAsync(question, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return question.Id;
        }

        //public Task<bool> DeleteAsync(Guid questionId, CancellationToken cancellationToken)
        //{

        //}

        public async Task<Question?> GetByIdAsync(Guid questionId, CancellationToken cancellationToken)
        {
            Question? question = await _dbContext.Questions
                .Include(q => q.Answers)
                .Include(q => q.Solution)
                .FirstOrDefaultAsync(q => q.Id == questionId, cancellationToken);

            return question;
        }

        public async Task<int> GetOpenUserQuestionsAsync(Guid userId, CancellationToken cancellationToken)
        {

            return _dbContext.Questions.Count(q => q.Status == QuestionStatus.Open);
        }

        //public Task<Guid> SaveAsync(Question question, CancellationToken cancellationToken)
        //{

        //}
    }
}