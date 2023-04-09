using ViewModels;

namespace RoadRiderAPI.Core.MapboxAPIs.Geocodings
{
    public interface IGeocodingService
    {
        Task<IEnumerable<GeocodingOutputModel>> ForwardGeocodingAsync(string search/*, bool autocomplete = false, string language = "us", int limit = 5*/);
        Task<GeocodingOutputModel> ReverseGeocodingAsync(double latitude, double longtitude/*, string language = "us", int limit = 5*/);
    }
}
