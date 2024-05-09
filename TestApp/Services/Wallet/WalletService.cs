using TestApp.Models;
using TestApp.Services.Interfaces;
using TestApp.Services.Interfaces.Wallet;

namespace TestApp.Services.Wallet
{
    public class WalletService : IWalletService
    {
        private readonly IWalletReporitory walletRepository;
        private readonly ITransactionRepository transactionRepository;
        public WalletService(IWalletReporitory walletRepository, ITransactionRepository transactionRepository)
        {
            this.walletRepository = walletRepository;
            this.transactionRepository = transactionRepository;
        }
        public async Task<ICollection<TransactionModel>> GetAllWalletTransactions(Guid walletId)
            => await transactionRepository.GetAllWalletTransaction(walletId);
    }
}
