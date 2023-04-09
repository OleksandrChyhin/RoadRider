using Microsoft.Extensions.Configuration;
using RoadRiderAPI.Core.HttpsClientServices;
using RoadRiderAPI.MapboxModels.Directions;
using RoadRiderAPI.MapboxModels.Geocoding;

namespace RoadRiderAPI.Core.MapboxAPIs.Directions
{
    public class DirectionsService : MapboxBase, IDirectionsService
    {
        protected override string APIName => "directions/v5";
        string Endpoint => "mapbox";
        public DirectionsService(IConfiguration configuration, IHttpClientService httpClientService) : base(configuration, httpClientService)
            {
    
            }
        public async Task<RouteDTO> RetrieveDirectionsAsync(string profile, IEnumerable<PointDTO> points)
        {
            var pointParams = string.Join(";", points.Select(x => $"{x.Latitude},{x.Longtitude}"));
            var url = $"{BaseUrl}{Endpoint}/{profile}/{pointParams}{TokenParameter}";
            var result = await _httpClientService.GetAsync<RouteDTO>(url);
            return result;

        }
    }
}
