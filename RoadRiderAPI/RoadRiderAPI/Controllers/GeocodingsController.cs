using Microsoft.AspNetCore.Mvc;
using RoadRiderAPI.Core.MapboxAPIs.Geocodings;

namespace RoadRiderAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeocodingsController : ControllerBase
    {
        readonly IGeocodingService _geocodingService;

        readonly ILogger<GeocodingsController> _logger;

        public GeocodingsController(ILogger<GeocodingsController> logger, IGeocodingService geocodingService)
        {
            _geocodingService = geocodingService;
            _logger = logger;
        }

        [HttpGet("ForwardGeocoding")]
        public async Task<IActionResult> GetForwardGeocoding(string query)
        {
            try
            {
                var result = await _geocodingService.ForwardGeocoding(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ReverseGeocoding")]
        public async Task<IActionResult> GetReverseGeocoding(double longtitude, double latitude)
        {
            try
            {
                var result = await _geocodingService.ReverseGeocoding(longtitude, latitude);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

    }
}
