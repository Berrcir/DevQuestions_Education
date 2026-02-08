using CSharpFunctionalExtensions;
using DevQuestions.Application.DataBase;
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
        private readonly IValidator<CreateQuestionDto> _createQuestionDtoValidator;
        private readonly IValidator<AddAnswerDto> _addAnswerDtoValidator;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionsService(
            IQuestionsRepository questionsRepository,
            IValidator<CreateQuestionDto> createQuestionDtoValidator,
            IValidator<AddAnswerDto> addAnswerDtoValidator,
            IUnitOfWork unitOfWork,
            ILogger<QuestionsService> logger)
        {
            _questionsRepository = questionsRepository;
            _createQuestionDtoValidator = createQuestionDtoValidator;
            _addAnswerDtoValidator = addAnswerDtoValidator;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result<Guid, Error[]>> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken)
        {
            // Валидация входного DTO
            ValidationResult validationResult = await _createQuestionDtoValidator.ValidateAsync(questionDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.ToErrors().ToArray();

                // throw new QuestionValidationException(validationResult.ToErrors());
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

        public async Task<Result<Guid, Error[]>> AddAnswer(
            Guid questionId,
            AddAnswerDto addAnswerDto,
            CancellationToken cancellationToken)
        {
            var validationResult = await _addAnswerDtoValidator.ValidateAsync(addAnswerDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.ToErrors().ToArray();
            }

            var transaction = await _unitOfWork.BeginTransactionAsync();

            var question = await _questionsRepository.GetByIdAsync(questionId, cancellationToken);

            if (question is null)
            {
                transaction.Rollback();
                throw new QuestionNotFoundException(questionId);
            }

            var answer = new Answer(Guid.NewGuid(), addAnswerDto.UserId, addAnswerDto.Text, questionId);

            question.Answers.Add(answer);

            await _questionsRepository.SaveAsync(question, cancellationToken);

            transaction.Commit();

            _logger.LogInformation("Answer added with id: {answerId} to question {questionId}", answer.Id, questionId);
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
    }
}