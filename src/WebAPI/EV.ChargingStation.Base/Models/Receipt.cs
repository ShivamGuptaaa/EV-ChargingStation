using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.ChargingStation.Base.Models
{
    public class Receipt
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 
        public double TotalAmount { get; set; }
        public double RatePerMinute { get; set; }
        public int TotalTime { get; set; } //time in minute
    }
}
