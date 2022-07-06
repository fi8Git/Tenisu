using Tenisu.Models;

namespace Tenisu.Services.Interfaces
{
    public interface IPlayerService
    {
        public List<PlayerModel> GetPlayerList();
        public PlayerModel? GetPlayerById(int id);
        public string GetCountryWithBestRatio(List<PlayerModel> players);
    }
}
