using TestApp.Models;

namespace TestApp.Services.Interfaces
{
    public interface ITransactionRepository : IGenericReporistory<TransactionModel>
    {
        Task<ICollection<TransactionModel>> GetAllWalletTransaction(Guid walletId);
        ICollection<TransactionModel> GetData();
    }
}
