using CSharpFunctionalExtensions;
using DevQuestions.Contracts.Questions;
using Shared;

namespace DevQuestions.Application.Questions
{
    public interface IQuestionsService
    {
        /// <summary>
        /// Создание вопроса.
        /// </summary>
        /// <param name="questionDto">DTO создания вопроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Результат работы метода. Либо Id созданного вопроса, либо Error.</returns>
        public Task<Result<Guid, Error[]>> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken);

        /// <summary>
        /// Добавление ответа на вопрос
        /// </summary>
        /// <param name="questionId">Id вопроса</param>
        /// <param name="addAnswerDto">DTO для добавления ответа на вопрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Результат работы метода - Либо Id, либо Error.</returns>
        public Task<Result<Guid, Error>> AddAnswer(
            Guid questionId,
            AddAnswerDto addAnswerDto,
            CancellationToken cancellationToken);
    }
}