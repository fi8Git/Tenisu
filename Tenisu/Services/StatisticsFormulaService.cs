using Tenisu.Services.Interfaces;

namespace Tenisu.Services
{
    public class StatisticsFormulaService : IStatisticsFormulaService
    {
        public double GetImcAverage(List<double> imcList)
        {
            if (imcList == null)
                throw new ArgumentNullException("le paramètre est null");

            if (imcList.Count == 0)
                throw new ArgumentException("la liste est vide");

            return imcList.Average(c => c);
        }

        public double GetMedian(List<double> data)
        {
            if (data == null)
                throw new ArgumentNullException("le paramètre est null");

            if (data.Count == 0)
                throw new ArgumentException("la liste est vide");

            data.Sort();

            int n = data.Count;

            if (n % 2 == 0)
            {
                int index = (n - 1) / 2;
                return (data[index] + data[index + 1]) / 2;
            }
            else
            {
                int index = n / 2;
                return data[index];
            }
        }
    }
}
