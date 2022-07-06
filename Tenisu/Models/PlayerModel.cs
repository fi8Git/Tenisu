namespace Tenisu.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Shortname { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public CountryModel Country { get; set; } = null!;
        public PlayerDataModel Data { get; set; } = null!;
    }
}
