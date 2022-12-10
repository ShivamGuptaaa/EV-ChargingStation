using EV.ChargingStation.Base.Data;
using EV.ChargingStation.Base.IRepositories;
using EV.ChargingStation.Base.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.CharginStation.Api.UnitTests.Mocks
{
    public class ChargingStationRepositoryMocks
    {
        public static Mock<IChargingStationRepository> GetChargingStationRepository() 
        {
            var mockChargingStationRepository = new Mock<IChargingStationRepository>();
            mockChargingStationRepository.Setup(repo => repo.GetSites()).Returns(Data.Sites);
            mockChargingStationRepository.Setup(repo => repo.GetSiteById(4)).Returns(Data.Sites.FirstOrDefault(x=>x.Id == 4));
            mockChargingStationRepository.Setup(repo => repo.GetReceipt(4,1.1,4)).Returns(new Receipt() { SiteId=4,SiteName="Delta EV Station",TotalAmount = 5.5,RatePerMinute = 1.1, TotalTime = 5});

            return mockChargingStationRepository;
        }
    }
}
