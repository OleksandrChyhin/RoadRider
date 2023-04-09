using Microsoft.AspNetCore.Mvc;
using RoadRiderAPI.Core.MapboxAPIs.Directions;
using RoadRiderAPI.MapboxModels.Directions;
using RoadRiderAPI.MapboxModels.Geocoding;

namespace RoadRiderAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class DirectionsController : ControllerBase
    {
        IDirectionsService _directionsService;
        ILogger<RouteDTO> _logger;

        public DirectionsController(IDirectionsService directionsService, ILogger<RouteDTO> logger)
        {
            _directionsService = directionsService;
            _logger = logger;
        }

        [HttpPost("RetrieweDirection")]
        public async Task<IActionResult> PostRetriweDirectionAsync(string code, [System.Web.Http.FromBody] ICollection<PointDTO> points)
        {         
            try
            {
                var result = await _directionsService.RetrieveDirectionsAsync(code, points);
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
