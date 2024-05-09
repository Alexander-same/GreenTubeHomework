using System.Data.Entity;
using TestApp.Models;
using TestApp.Models.Enums;
using TestApp.Services.Interfaces;

namespace TestApp.Services.Repositories
{
    public class TransactionRepository : GenericRepository<TransactionModel>, ITransactionRepository
    {
        public async Task<ICollection<TransactionModel>> GetAllWalletTransaction(Guid walletId)
        {
            //return await table.Where(x => x.WalletId == walletId).ToListAsync();
            return GetData();
        }

        public ICollection<TransactionModel> GetData()
        {
            return new List<TransactionModel>
            {
                new TransactionModel
                {
                    WalletId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    TransactionStatus = TransactionStatusEnum.Approved,
                    Amount = 10,
                    CreatedDate  = DateTime.Now,
                    PlayerId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    TransactionType = TransactionTypeEnum.DEPOSIT,
                    GuidId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                },
                new TransactionModel
                {
                    WalletId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    TransactionStatus = TransactionStatusEnum.Approved,
                    Amount = 10,
                    CreatedDate  = DateTime.Now,
                    PlayerId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    TransactionType = TransactionTypeEnum.STAKE,
                    GuidId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                },
            };
        }
    }
}
