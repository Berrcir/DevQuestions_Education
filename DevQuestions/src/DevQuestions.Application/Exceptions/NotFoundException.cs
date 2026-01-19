namespace DevQuestions.Application.Exceptions
{
    public class NotFoundException<T> : Exception
    {
        protected NotFoundException(Guid id)
            : base($"{nameof(T)} with id: {id} not found")
        {
        }
    }
}