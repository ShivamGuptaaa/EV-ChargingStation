using EV.ChargingStation.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EV.ChargingStation.Base.Data
{
    public static class Data
    {
        private static readonly List<Site> sites = new() {
            new Site() { Id = 1, Name="Alpha EV Station", AreaName="Gandhi Nagar", RatePerMinute = 1},
            new Site() { Id = 2, Name="Beta EV Station", AreaName="Bhagat Nagar", RatePerMinute = 1.2},
            new Site() { Id = 3, Name="Gamma EV Station", AreaName="Patel Nagar", RatePerMinute = 0.8},
            new Site() { Id = 4, Name="Delta EV Station", AreaName="Bose Nagar", RatePerMinute = 1.1}
        };

        public static List<Site> Sites => sites;
        public static void LockSocket(int Id, bool setLock) => sites.FirstOrDefault(x => x.Id == Id).IsLocked = setLock;

    }
}
