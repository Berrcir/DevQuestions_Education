using System.Data;

namespace DevQuestions.Application.DataBase
{
    public interface IUnitOfWork
    {
        public Task<IDbTransaction> BeginTransactionAsync();
    }
}
