using TestApp.Models;
using TestApp.Services.Interfaces;
using TestApp.Services.Interfaces.Transaction;
using TestApp.Services.Interfaces.Wallet;

namespace TestApp.Services.Transaction
{
    public class WinTransactionStrategy : ITransactionStrategy
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IWalletReporitory walletReporitory;
        public WinTransactionStrategy(ITransactionRepository transactionRepository, IWalletReporitory walletReporitory)
        {
            this.transactionRepository = transactionRepository;
            this.walletReporitory= walletReporitory;
        }

        public async Task<string> ProcessTransaction(TransactionModel transaction)
        {
            transaction.TransactionStatus = Models.Enums.TransactionStatusEnum.Approved;
            transaction.GuidId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            //await transactionRepository.Add(transaction);
            var trData = transactionRepository.GetData();
            trData.Add(transaction);


            var walletData = walletReporitory.GetData();
            var wallet = walletData.First();
            //var wallet = await walletReporitory.GetById(transaction.WalletId);
            wallet.Amount += transaction.Amount;
            //await walletReporitory.Update(wallet);
            return $"Transaction {transaction.GuidId} is {transaction.TransactionStatus}";
        }
    }
}
