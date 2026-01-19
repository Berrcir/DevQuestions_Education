using DevQuestions.Application;
using DevQuestions.Infrastructure.PostgreSql;

namespace DevQuestions.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProgramDependencies(this IServiceCollection services) =>
             services
                .AddWebDependencies()
                .AddApplication()
                .AddPostgreSqlInfrastructure();

        private static IServiceCollection AddWebDependencies(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            return services;
        }
    }
}