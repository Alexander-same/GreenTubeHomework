using TestApp.Models;

namespace TestApp.Services.Interfaces.Transaction
{
    public interface ITransactionStrategy
    {
        Task<string> ProcessTransaction(TransactionModel transaction);
    }
}
