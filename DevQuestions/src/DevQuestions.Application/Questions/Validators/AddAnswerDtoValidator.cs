using DevQuestions.Contracts.Questions;
using FluentValidation;

namespace DevQuestions.Application.Questions.Validators
{
    public class AddAnswerDtoValidator : AbstractValidator<AddAnswerDto>
    {
        public AddAnswerDtoValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                    .WithErrorCode("answer.text.is.empty") 
                    .WithMessage("Текст ответа не должен быть пустым")
                .MaximumLength(5000)
                    .WithErrorCode("answer.text.length.too.long")
                    .WithMessage("Текст ответа слишком длинный");

            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}