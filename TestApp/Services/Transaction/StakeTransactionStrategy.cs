using TestApp.Models;
using TestApp.Services.Interfaces;
using TestApp.Services.Interfaces.Transaction;
using TestApp.Services.Interfaces.Wallet;

namespace TestApp.Services.Transaction
{
    public class StakeTransactionStrategy : ITransactionStrategy
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IWalletReporitory walletReporitory;
        public StakeTransactionStrategy(ITransactionRepository transactionRepository, IWalletReporitory walletReporitory)
        {
            this.transactionRepository = transactionRepository;
            this.walletReporitory = walletReporitory;
        }

        public async Task<string> ProcessTransaction(TransactionModel transaction)
        {
            var walletData = walletReporitory.GetData();
            var wallet = walletData.First();

            var transactionData = transactionRepository.GetData();
            //var wallet = await walletReporitory.GetById(transaction.WalletId);
            if (wallet.Amount < transaction.Amount)
            {
                transaction.TransactionStatus = Models.Enums.TransactionStatusEnum.Rejected;
                transaction.GuidId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");


                transactionData.Add(transaction);
                //await transactionRepository.Add(transaction);
                return $"Transaction {transaction.GuidId} is {transaction.TransactionStatus}";
            }

            wallet.Amount -= transaction.Amount;
            //await walletReporitory.Update(wallet);


            transaction.TransactionStatus = Models.Enums.TransactionStatusEnum.Approved;
            transaction.GuidId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            transactionData.Add(transaction);
            //await transactionRepository.Add(transaction);
            return $"Transaction {transaction.GuidId} is {transaction.TransactionStatus}";
        }
    }
}
