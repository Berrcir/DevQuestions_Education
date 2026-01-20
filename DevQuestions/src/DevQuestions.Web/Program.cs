using DevQuestions.Web;
using DevQuestions.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProgramDependencies();

var app = builder.Build();

app.UseExceptionMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "DevQuestions"));
}

app.MapControllers();

app.Run();