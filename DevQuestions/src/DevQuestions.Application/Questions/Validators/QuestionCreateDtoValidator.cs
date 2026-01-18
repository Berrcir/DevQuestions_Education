using DevQuestions.Contracts.Questions;
using FluentValidation;

namespace DevQuestions.Application.Questions.Validators
{
    public class QuestionCreateDtoValidator: AbstractValidator<QuestionCreateDto>
    {
        public QuestionCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(500).WithMessage("Заголовок невалидный");

            RuleFor(x => x.Text)
                .NotEmpty()
                .MaximumLength(5000).WithMessage("Текст вопроса невалидный");

            RuleFor(x => x.UserId).NotEmpty();

            RuleForEach(x => x.TagIds).NotEmpty();
        }
    }
}