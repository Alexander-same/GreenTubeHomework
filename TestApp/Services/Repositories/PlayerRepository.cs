using TestApp.Models;
using TestApp.Models.Enums;
using TestApp.Services.Interfaces.Player;

namespace TestApp.Services.Repositories
{
    public class PlayerRepository : GenericRepository<PlayerModel>, IPlayerRepository
    {
        public ICollection<PlayerModel> GetData()
        {
            return new List<PlayerModel>
            {
                new PlayerModel
                {
                    GuidId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    Name = "MegaGamer1",
                },
                new PlayerModel
                {
                    GuidId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    Name = "MegaGamer2",
                },
            };
        }
    }
}
