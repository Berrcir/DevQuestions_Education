namespace DevQuestions.Presenters.Questions.Models
{
    public record class CreateQuestionModel(string Title, string Text, Guid UserId, Guid[]? TagIds);
}