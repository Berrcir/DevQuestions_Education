using System.Diagnostics.CodeAnalysis;
using DevQuestions.Domain.Questions;

namespace DevQuestions.Domain.Questions
{
    public class Question
    {
        public Guid Id { get; set; }

        public required string Title { get; set; }

        public required string Text { get; set; }

        public required Guid UserId { get; set; }

        public IEnumerable<Answer> Answers { get; set; } = [];

        public Answer? Solution { get; set; }

        public List<Guid> Tags { get; set; } = [];

        public QuestionStatus Status { get; set; }

        [SetsRequiredMembers]
        public Question(
            Guid id,
            string title,
            string text,
            Guid userId,
            IEnumerable<Guid> tags)
        {
            Id = id;
            Title = title;
            Text = text;
            UserId = userId;
            Tags = tags.ToList();
            Status = QuestionStatus.Open;
        }
    }
}