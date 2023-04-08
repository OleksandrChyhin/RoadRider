using Microsoft.AspNetCore.Mvc;
using RoadRiderAPI.Core.MapboxAPIs.Geocodings;

namespace RoadRiderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeocodingsController : ControllerBase
    {
        readonly IGeocodingService _geocodingService;

        readonly ILogger<GeocodingsController> _logger;

        public GeocodingsController(ILogger<GeocodingsController> logger, IGeocodingService geocodingService)
        {
            _geocodingService= geocodingService;
            _logger = logger;
        }
        [HttpGet(Name = "ForwardGeocoding")]
        public async Task<IActionResult> Get(string query)
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

    }
}
