using EV.ChargingStation.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.ChargingStation.Base.IRepositories
{
    public interface IChargingStationRepository
    {
        List<Site> GetSites();
        Site GetSiteById(int Id);
        Receipt GetReceipt(int TotalMinutes, double RatePerMinute, int SiteId);

    }
}
