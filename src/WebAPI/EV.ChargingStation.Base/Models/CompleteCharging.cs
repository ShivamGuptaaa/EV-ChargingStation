using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.ChargingStation.Base.Models
{
    public class CompleteCharging
    {
        public int MinutesConsumed { get; set; }
        public int SiteId { get; set; }
    }
}
