namespace Tenisu.Services.Interfaces
{
    public interface IStatisticsFormulaService
    {
        public double GetImcAverage(List<double> imcList);
        public double GetMedian(List<double> data);
    }
}
