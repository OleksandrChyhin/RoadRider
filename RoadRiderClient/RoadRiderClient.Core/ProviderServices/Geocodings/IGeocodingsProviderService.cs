using RoadRiderClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoadRiderClient.Core.ProviderServices.Geocodings
{
    public interface IGeocodingsProviderService
    {
        Task<IEnumerable<GeocodingDTO>> GetForwardGeocodingAsync(string searchQuery);
        Task<IEnumerable<GeocodingDTO>> GetReverseGeocodingAsync(string searchQuery);
        Task<IEnumerable<GeocodingDTO>> GetGeolocationByPlacementType(string search,
                                                                      double lat,
                                                                      double @long,
                                                                      string type,
                                                                      int limit = 10);
    }
}
