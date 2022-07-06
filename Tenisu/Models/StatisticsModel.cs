namespace Tenisu.Models
{
    public class StatisticsModel
    {
        public string CountryWithBestRatio { get; set; } = string.Empty;
        public double ImcAverageOfPlayers { get; set; }
        public double MedianOfPlayersHeight { get; set; }
    }
}
