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
        public async Task<IActionResult> GetForwardGeocodingAsync(string query)
        {
            try
            {
                var result = await _geocodingService.ForwardGeocodingAsync(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ReverseGeocoding")]
        public async Task<IActionResult> GetReverseGeocoding(double latitude, double longtitude)
        {
            try
            {
                var result = await _geocodingService.ReverseGeocodingAsync(latitude, longtitude);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetGeolocationByPlacementTypeAsync")]
        public async Task<IActionResult> GetGeolocationByPlacementType(string search, double latitude, double longtitude, string type, int limit)
        {
            try
            {
                var result = await _geocodingService.GetGeolocationByPlacementTypeAsync(search, latitude, longtitude, type, limit);
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
