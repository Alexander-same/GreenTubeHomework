using TestApp.Models;
using TestApp.Models.Enums;
using TestApp.Services.Interfaces.Wallet;

namespace TestApp.Services.Repositories
{
    public class WalletRepository : GenericRepository<WalletModel>, IWalletReporitory
    {
        public override async Task Add(WalletModel wallet)
        {
            if (table.FirstOrDefault(x => x.PlayerId == wallet.PlayerId) != null)
            {
                throw new Exception("This player already have wallet.");
            }

            wallet.GuidId= Guid.NewGuid();
            //table.Add(wallet);
            //await SaveAsync();
            var data = GetData();
            data.Add(wallet);
        }

        public ICollection<WalletModel> GetData()
        {
            return new List<WalletModel>
            {
                new WalletModel
                {
                    Amount = 10,
                    GuidId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    PlayerId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
                },
                new WalletModel
                {
                    Amount = 10,
                    GuidId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    PlayerId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
                },
            };
        }
    }
}
