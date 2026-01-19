using Dapper;
using DevQuestions.Application.Questions;
using DevQuestions.Domain.Questions;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DevQuestions.Infrastructure.PostgreSql.Repositories
{
    public class QuestionsSqlRepository : IQuestionsRepository
    {
        private readonly IConfiguration _configuration;

        public QuestionsSqlRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Guid> AddAsync(Question question, CancellationToken cancellationToken)
        {
            const string sql = """
                               INSERT INTO questions (id, title, text, user_id, tags, status)
                               VALUES (@Id, @Title, @Text, @UserId, @Tags, @Status)
                               """;

            await using var connection = new NpgsqlConnection(_configuration.GetConnectionString("Database"));

            await connection.ExecuteAsync(sql, new
            {
                Id = question.Id,
                Title = question.Title,
                Text = question.Text,
                UserId = question.UserId,
                Tags = question.Tags.ToArray(),
                Status = question.Status,
            });

            return question.Id;
        }

        //public Task<bool> DeleteAsync(Guid questionId, CancellationToken cancellationToken)
        //{

        //}

        //public Task<Question> GetByIdAsync(Guid questionId, CancellationToken cancellationToken)
        //{

        //}

        public Task<int> GetOpenUserQuestionsAsync(Guid userId, CancellationToken cancellationToken)
        {
            Thread.Sleep(1000);

            return Task.FromResult(0);
        }

        //public Task<Guid> SaveAsync(Question question, CancellationToken cancellationToken)
        //{

        //}
    }
}