using DevQuestions.Application.Questions;
using DevQuestions.Application.Questions.Validators;
using DevQuestions.Contracts.Questions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DevQuestions.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IValidator<QuestionCreateDto>, QuestionCreateDtoValidator>();
            services.AddScoped<IQuestionsService, QuestionsService>();

            return services;
        }
    }
}