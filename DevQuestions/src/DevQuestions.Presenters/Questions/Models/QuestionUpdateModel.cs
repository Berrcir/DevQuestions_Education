namespace DevQuestions.Presenters.Questions.Models
{
    public record class QuestionUpdateModel(string Title, string Text, Guid[]? TagIds);
}