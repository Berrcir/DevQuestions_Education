namespace DevQuestions.Presenters.Questions.Models
{
    public record class UpdateQuestionModel(string Title, string Text, Guid[]? TagIds);
}