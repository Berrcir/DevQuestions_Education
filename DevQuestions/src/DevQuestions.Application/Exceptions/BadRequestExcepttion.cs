namespace DevQuestions.Application.Exceptions
{
    public class BadRequestExcepttion : Exception
    {
        protected BadRequestExcepttion(string message)
            : base(message)
        {
        }

        protected BadRequestExcepttion(IEnumerable<string> errors)
            : base(String.Join("\n", errors))
        {
        }
    }
}