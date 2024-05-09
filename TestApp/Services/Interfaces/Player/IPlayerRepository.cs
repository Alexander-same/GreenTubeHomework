using TestApp.Models;

namespace TestApp.Services.Interfaces.Player
{
    public interface IPlayerRepository : IGenericReporistory<PlayerModel>
    {
        ICollection<PlayerModel> GetData();
    }
}
