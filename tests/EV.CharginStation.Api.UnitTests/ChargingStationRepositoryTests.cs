using EV.ChargingStation.Base.IRepositories;
using EV.ChargingStation.Base.Models;
using EV.CharginStation.Api.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace EV.CharginStation.Api.UnitTests
{
    public class ChargingStationRepositoryTests
    {
        public readonly Mock<IChargingStationRepository> _mockChargingStationRepository;

        public ChargingStationRepositoryTests()
        {
            _mockChargingStationRepository = ChargingStationRepositoryMocks.GetChargingStationRepository();
        }

        [Fact]
        public void GetAllSites()
        {
            var result = _mockChargingStationRepository.Object.GetSites();
            result.ShouldBeOfType<List<Site>>();
            result.ShouldNotBeEmpty();
        }

        [Fact]
        public void GetSiteById() 
        {
            var result = _mockChargingStationRepository.Object.GetSiteById(4);
            result.ShouldBeOfType<Site>();
            result.Name.ShouldBe("Delta EV Station");
        }

        public void GetReceipt() 
        {
            var result = _mockChargingStationRepository.Object.GetReceipt(4, 1.1, 5);
            result.ShouldBeOfType<Receipt>();
            result.TotalAmount.ShouldBe(5.5);
        }
    }
}