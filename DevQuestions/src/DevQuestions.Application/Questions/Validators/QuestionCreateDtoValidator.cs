using DevQuestions.Contracts.Questions;
using FluentValidation;

namespace DevQuestions.Application.Questions.Validators
{
    public class QuestionCreateDtoValidator : AbstractValidator<QuestionCreateDto>
    {
        public QuestionCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                    .WithErrorCode("question.title.is.empty")
                    .WithMessage("Заголовок невалидный")
                .MaximumLength(500)
                    .WithErrorCode("question.title.length.too.long");

            RuleFor(x => x.Text)
                .NotEmpty()
                    .WithErrorCode("question.text.is.invalid")
                    .WithMessage("Текст вопроса невалидный")
                .MaximumLength(5000).WithMessage("Текст вопроса слишком длинный");

            RuleFor(x => x.UserId).NotEmpty();

            RuleForEach(x => x.TagIds).NotEmpty();
        }
    }
}