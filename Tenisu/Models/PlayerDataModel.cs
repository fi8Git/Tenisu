namespace Tenisu.Models
{
    public class PlayerDataModel
    {
        public int Rank { get; set; }
        public int Points { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public List<int> Last { get; set; } = new List<int>();

        public double GetImcOfPlayer()
        {
            double weightInKg = GetWeightInKg();
            double heightInM = GetHeightInM();

            double result = weightInKg / Math.Pow(heightInM, 2);
            return Math.Round(result, 2);
        }

        public double GetHeightInM()
        {
            return Height / (double)100;
        }

        public double GetWeightInKg()
        {
            return Weight / (double)1000;
        }
    }
}
