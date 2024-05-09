using TestApp.Models;

namespace TestApp.Services.Interfaces.Wallet
{
    public interface IWalletReporitory : IGenericReporistory<WalletModel>
    {
        ICollection<WalletModel> GetData();
    }
}
