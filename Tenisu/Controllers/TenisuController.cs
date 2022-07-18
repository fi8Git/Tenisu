using Microsoft.AspNetCore.Mvc;
using Tenisu.Models;
using Tenisu.Services.Interfaces;

namespace Tenisu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenisuController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IStatisticsFormulaService _statService;

        public TenisuController(IPlayerService playerService, IStatisticsFormulaService statService)
        {
            _playerService = playerService;
            _statService = statService;
        }

        [HttpGet("[action]")]
        public ActionResult<List<PlayerModel>> GetListPlayersOrderByRank()
        {
            var listPlayer = _playerService.GetPlayerList();

            return listPlayer.OrderBy(p => p.Data.Rank).ToList();
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<PlayerModel> GetPlayerById(int id)
        {
            var player = _playerService.GetPlayerById(id);

            if (player == null)
                return NotFound();

            return player;
        }

        [HttpGet("[action]")]
        public ActionResult<StatisticsModel> GetPlayersStatistics()
        {
            var players = _playerService.GetPlayerList();
            var imcList = players.Select(p => p.Data.GetImcOfPlayer()).ToList();
            var playersHeight = players.Select(p => p.Data.GetHeightInM()).ToList();

            var playersStats = new StatisticsModel()
            {
                CountryWithBestRatio = _playerService.GetCountryWithBestRatio(players),
                ImcAverageOfPlayers = _statService.GetImcAverage(imcList),
                MedianOfPlayersHeight = _statService.GetMedian(playersHeight),
            };

            return playersStats;
        }
    }
}
