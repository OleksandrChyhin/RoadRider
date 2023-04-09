using RoadRiderAPI.MapboxModels.Directions;
using RoadRiderAPI.MapboxModels.Geocoding;

namespace RoadRiderAPI.Core.MapboxAPIs.Directions
{
    public interface IDirectionsService
    {
        Task<RouteDTO> RetrieveDirectionsAsync(string profile, IEnumerable<PointDTO> points);
    }
}
