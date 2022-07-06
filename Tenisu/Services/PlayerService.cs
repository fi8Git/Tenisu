using Newtonsoft.Json;
using Tenisu.Models;
using Tenisu.Services.Interfaces;

namespace Tenisu.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly string _data = File.ReadAllText(@"Data\DataPlayers.json");

        private DataModel GetData()
        {
            var model = JsonConvert.DeserializeObject<DataModel>(_data);

            if (model == null)
                throw new ArgumentNullException("le modele retourne null, lors de la deserialisation des données");

            return model;
        }

        public string GetCountryWithBestRatio(List<PlayerModel> players)
        {
            if (players == null)
                throw new ArgumentNullException("le paramètre est null");

            if (players.Count == 0)
                throw new ArgumentException("la liste des joueurs fournis en paramètre est vide");

            // Groupe les différents joueurs par pays
            var playerGroupByCountry = players.GroupBy(p => p.Country.Code);

            // Crée une liste de pair pays/ratio
            var countryWithRatio = playerGroupByCountry.Select(group => new
            {
                country = group.Key,
                ratio = group.SelectMany(p => p.Data.Last).Sum() / group.SelectMany(p => p.Data.Last).Count()
            });

            // retourne le code du pays ayant le meilleur ratio
            return countryWithRatio.MaxBy(c => c.ratio)!.country;
        }

        public List<PlayerModel> GetPlayerList()
        {
            var data = GetData();

            if (data.Players.Count == 0)
                throw new ArgumentException("la liste des joueurs est vide");

            return data.Players;
        }

        public PlayerModel? GetPlayerById(int id)
        {
            return GetPlayerList().Find(p => p.Id == id);
        }
    }
}
