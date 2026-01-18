namespace DevQuestions.Presenters.Questions.Models
{
    public record class QuestionCreateModel(string Title, string Text, Guid UserId, Guid[]? TagIds);
}