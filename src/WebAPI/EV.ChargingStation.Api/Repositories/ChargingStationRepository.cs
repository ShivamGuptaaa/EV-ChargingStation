using EV.ChargingStation.Base.Data;
using EV.ChargingStation.Base.IRepositories;
using EV.ChargingStation.Base.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EV.ChargingStation.Repositories
{
    public class ChargingStationRepository : IChargingStationRepository
    {
        readonly ILogger<ChargingStationRepository> _logger;

        public ChargingStationRepository(ILogger<ChargingStationRepository> logger)
        {
            _logger = logger;
        }


        public Receipt GetReceipt(int TotalMinutes, double RatePerMinute, int SiteId)
        {
            _logger.LogInformation("Get Receipt Initiated");
            Data.LockSocket(SiteId, true);
            _logger.LogInformation("Get Receipt Completed");
            return new Receipt() { TotalTime = TotalMinutes, RatePerMinute = RatePerMinute, TotalAmount = TotalMinutes * RatePerMinute };
        }

        public Site GetSiteById(int Id)
        {
            _logger.LogInformation("Get Sites By Id Initiated for Id: " + Id);
            Site site = Data.Sites.FirstOrDefault(x => x.Id == Id);
            if (site == null) { 
                _logger.LogError("Not Found Site with Id: " + Id);
                return null;
            }

            _logger.LogInformation("Get Sites By Id Completed for Id: " + Id);
            return site;
        }

        public List<Site> GetSites()
        {
            _logger.LogInformation("Get Sites Method Initiated");
            return Data.Sites;
        }
    }
}
