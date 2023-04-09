using RoadRiderAPI.MapboxModels.Geocoding;
using ViewModels;

namespace RoadRiderAPI.Core.MapboxAPIs.Geocodings
{
    public interface IGeocodingService
    {
        Task<IEnumerable<GeocodingOutputModel>> ForwardGeocodingAsync(string search);

        Task<GeocodingOutputModel> ReverseGeocodingAsync(double latitude, double longtitude);

        Task<IEnumerable<GeocodingOutputModel>> GetGeolocationByPlacementTypeAsync(string search, double latitude, double longtitude, string type, int limit);       
    }
}
