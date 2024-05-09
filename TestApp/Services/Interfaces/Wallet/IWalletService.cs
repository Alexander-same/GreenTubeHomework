using TestApp.Models;

namespace TestApp.Services.Interfaces.Wallet
{
    public interface IWalletService
    {
        Task<ICollection<TransactionModel>> GetAllWalletTransactions(Guid walletId);
    }
}
