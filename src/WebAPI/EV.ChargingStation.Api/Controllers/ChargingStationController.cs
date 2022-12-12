using EV.ChargingStation.Base.Data;
using EV.ChargingStation.Base.IRepositories;
using EV.ChargingStation.Base.Models;
using Microsoft.AspNetCore.Mvc;

namespace EV.ChargingStation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChargingStationController : Controller
    {
        private readonly ILogger<ChargingStationController> _logger;
        private readonly IChargingStationRepository _chargingStationRepository;

        public ChargingStationController(ILogger<ChargingStationController> logger, IChargingStationRepository chargingStationRepository)
        {
            _logger = logger;
            _chargingStationRepository = chargingStationRepository;
        }

        [HttpGet]
        public IActionResult GetAllSites()
        {
            _logger.LogInformation("GetAllSites Action Initiated");
            return Ok(_chargingStationRepository.GetSites());
        }

        [HttpGet("{Id}")]
        public IActionResult GetSiteById(int Id)
        {
            _logger.LogInformation("GetSiteById Action Initiated");
            var site = _chargingStationRepository.GetSiteById(Id);
            if(site == null)
                return NotFound();
            return Ok(site);
        }

        [HttpPost("CompleteCharging")]
        public IActionResult CompleteCharging(CompleteCharging completeCharging) 
        {
            _logger.LogInformation("CompleteCharging Action Initiated");
            Site site = _chargingStationRepository.GetSiteById(completeCharging.SiteId);
            var response = _chargingStationRepository.GetReceipt(completeCharging.MinutesConsumed, site.RatePerMinute, completeCharging.SiteId);
            return Ok(response);
        }

        [HttpPost("UnlockChargingStation")]
        public IActionResult UnlockChargingStation(UnlockSocket unlockSocket) 
        {
            _logger.LogInformation("UnlockChargingStation Action initiated");
            Data.LockSocket(unlockSocket.SiteId, false);
            return Ok();
        }
    }
}
