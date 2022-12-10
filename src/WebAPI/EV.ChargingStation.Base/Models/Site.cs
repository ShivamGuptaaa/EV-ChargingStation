using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.ChargingStation.Base.Models
{
    public class Site
    {
        public int Id { get; set; } //Guid is preferable for all type of Ids but used int for keeping it simple
        public string Name { get; set; }
        public string AreaName { get; set; }
        public bool IsLocked { get; set;} = true;
        public double RatePerMinute { get; set; }
    }
}
