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
    public class PlayerServiceTests
    {
        private readonly IPlayerService _playerService;

        public PlayerServiceTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IPlayerService, PlayerService>();

            var serviceProvider = services.BuildServiceProvider();

            _playerService = serviceProvider.GetService<IPlayerService>()!;
        }

        [TestMethod()]
        public void GetCountryWithBestRatio_WithValidGetPlayerListData_chekResult()
        {

            try
            {
                var players = _playerService.GetPlayerList();
                string result = _playerService.GetCountryWithBestRatio(players);

                Assert.AreEqual(result, "SRB");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void GetPlayerById_WithValidData_GetRightPlayer()
        {
            try
            {
                var player = _playerService.GetPlayerById(52);
                Assert.AreEqual(player!.Firstname, "Novak");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}