using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tenisu.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenisu.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Tenisu.Services.Tests
{
    [TestClass()]
    public class StatisticsFormulaServiceTests
    {
        private readonly IStatisticsFormulaService _statService;

        public StatisticsFormulaServiceTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IStatisticsFormulaService, StatisticsFormulaService>();

            var serviceProvider = services.BuildServiceProvider();

            _statService = serviceProvider.GetService<IStatisticsFormulaService>()!;
        }

        [TestMethod()]
        public void GetImcAverage_WithValidData_CalculImcAverage()
        {
            List<double> data = new List<double>() { 22, 30.8, 28.5, 20.2, 38 };

            try
            {
                _statService.GetImcAverage(data);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void GetImcAverage_WithValidNullData_CatchException()
        {
            try
            {
                double result = _statService.GetImcAverage(null);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "le paramètre est null");
                return;
            }

            Assert.Fail("exception non trouvée");
        }

        [TestMethod()]
        public void GetMedian_WithWikiEvenDataEx_CaluclMedian()
        {
            List<double> data = new List<double>() { 5, 6, 8, 7 };

            try
            {
                double result = _statService.GetMedian(data);
                Assert.AreEqual(result, 6.5);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void GetMedian_WithWikiOddDataEx_CaluclMedian()
        {
            List<double> data = new List<double>() { 5, 6, 12, 8, 7 };

            try
            {
                double result = _statService.GetMedian(data);
                Assert.AreEqual(result, 7);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}