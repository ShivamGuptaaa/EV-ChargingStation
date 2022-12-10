
using Castle.Core.Logging;
using EV.ChargingStation.Base.IRepositories;
using EV.ChargingStation.Base.Models;
using EV.ChargingStation.Controllers;
using EV.CharginStation.Api.UnitTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EV.CharginStation.Api.UnitTests
{
    public class ChargingStationControllerTests
    {
        private readonly Mock<IChargingStationRepository> _mockChargingStationRepository;
        private readonly Mock<ILogger<ChargingStationController>> _mockLogger;
        public ChargingStationControllerTests()
        {
            _mockChargingStationRepository = ChargingStationRepositoryMocks.GetChargingStationRepository();
            _mockLogger = new Mock<ILogger<ChargingStationController>>();
        }

        [Fact]
        public void GetAllSites()
        {

            var controller = new ChargingStationController(_mockLogger.Object, _mockChargingStationRepository.Object);
            var result = controller.GetAllSites();
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<List<Site>>();
        }


        [Fact]
        public void GetSiteById()
        {
            var controller = new ChargingStationController(_mockLogger.Object, _mockChargingStationRepository.Object);
            var result = controller.GetSiteById(4);
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Site>();
        }


        [Fact]
        public void CompleteCharging()
        {
            var controller = new ChargingStationController(_mockLogger.Object, _mockChargingStationRepository.Object);
            var result = controller.CompleteCharging(4,4);
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Receipt>();
        }


        [Fact]
        public void UnlockChargingStation()
        {
            var controller = new ChargingStationController(_mockLogger.Object, _mockChargingStationRepository.Object);
            var result = controller.UnlockChargingStation(1);
            result.ShouldBeOfType<OkResult>();
        }


    }
}
