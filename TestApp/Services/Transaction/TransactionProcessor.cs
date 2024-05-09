using TestApp.Models;
using TestApp.Models.Enums;
using TestApp.Services.Interfaces;
using TestApp.Services.Interfaces.Transaction;
using TestApp.Services.Interfaces.Wallet;

namespace TestApp.Services.Transaction
{
    public class TransactionProcessor
    {
        private readonly Dictionary<string, ITransactionStrategy> _strategies;

        public TransactionProcessor(ITransactionRepository transactionRepository, IWalletReporitory walletReporitory)
        {
            _strategies = new Dictionary<string, ITransactionStrategy>
        {
            { "DEPOSIT", new DepositTransactionStrategy(transactionRepository, walletReporitory) },
            { "STAKE", new StakeTransactionStrategy(transactionRepository, walletReporitory) },
            { "WIN", new WinTransactionStrategy(transactionRepository, walletReporitory) }
        };
        }

        public async Task<string> ProcessTransaction(TransactionModel transaction)
        {
            if (_strategies.TryGetValue(Enum.GetName(typeof(TransactionTypeEnum),
                transaction.TransactionType), out var strategy))
            {
                return await strategy.ProcessTransaction(transaction);
            }
            else
            {
                return "Unknow transaction type.";
            }
        }
    }
}
