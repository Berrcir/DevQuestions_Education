using CSharpFunctionalExtensions;
using DevQuestions.Application.Extensions;
using DevQuestions.Application.Questions.Fails.Exceptions;
using DevQuestions.Contracts.Questions;
using DevQuestions.Domain.Questions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Shared;

namespace DevQuestions.Application.Questions
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly ILogger<QuestionsService> _logger;
        private readonly IValidator<QuestionCreateDto> _validator;

        public QuestionsService(
            IQuestionsRepository questionsRepository,
            IValidator<QuestionCreateDto> validator,
            ILogger<QuestionsService> logger)
        {
            _questionsRepository = questionsRepository;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result<Guid, Error[]>> Create(QuestionCreateDto questionDto, CancellationToken cancellationToken)
        {
            // Валидация входного DTO
            ValidationResult validationResult = await _validator.ValidateAsync(questionDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.ToErrors().ToArray();

                //throw new QuestionValidationException(validationResult.ToErrors());
            }

            // Валидация бизнес-логики
            int openUserQuestionsCount = await _questionsRepository
                .GetOpenUserQuestionsAsync(questionDto.UserId, cancellationToken);

            if (openUserQuestionsCount > 3)
            {
                throw new TooManyQuestionsException();
            }

            Guid questionId = Guid.NewGuid();

            Question question = new(
                questionId,
                questionDto.Title,
                questionDto.Text,
                questionDto.UserId,
                questionDto.TagIds ?? []
            );

            await _questionsRepository.AddAsync(question, cancellationToken);

            _logger.LogInformation("Question created with id {questionId}", questionId);

            return questionId;
        }

        //public async Task<IActionResult> Update(
        //    Guid questionId,
        //    QuestionUpdateModel model,
        //    CancellationToken cancellationToken)
        //{

        //}

        //public async Task<IActionResult> DeleteById(Guid questionId, CancellationToken cancellationToken)
        //{

        //}

        //public async Task<IActionResult> Resolve(
        //    Guid questionId,
        //    Guid answerId,
        //    CancellationToken cancellationToken)
        //{

        //}

        //public async Task<IActionResult> AddAnswer(
        //    Guid questionId,
        //    AnswerAddModel model,
        //    CancellationToken cancellationToken)
        //{

        //}
    }
}