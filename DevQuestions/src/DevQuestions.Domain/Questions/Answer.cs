using System.Diagnostics.CodeAnalysis;

namespace DevQuestions.Domain.Questions
{
    public class Answer
    {
        public Guid Id { get; set; }

        public required Guid UserId{ get; set; }

        public required string Text { get; set; }

        public required Guid QuestionId { get; init; }

        public Question Question { get; set; } = null!;

        public List<Guid> Comments { get; set; } = [];

        public int Rating { get; set; }

        [SetsRequiredMembers]
        public Answer(Guid id, Guid userId, string text, Guid questionId)
        {
            Id = id;
            UserId = userId;
            Text = text;
            QuestionId = questionId;
            Comments = [];
            Rating = 0;
        }
    }
}