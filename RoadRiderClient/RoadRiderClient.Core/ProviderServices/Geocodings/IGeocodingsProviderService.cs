using RoadRiderClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoadRiderClient.Core.ProviderServices.Geocodings
{
    public interface IGeocodingsProviderService
    {
        Task<IEnumerable<GeocodingDTO>> GetForwardGeocodingAsync(string searchQuery);
        Task<IEnumerable<GeocodingDTO>> GetReverseGeocodingAsync(string searchQuery);
    }
}
