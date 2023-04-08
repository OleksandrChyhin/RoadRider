using RoadRiderClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoadRiderClient.Core.ProviderServices.Geocodings
{
    public interface IGeocodingsProviderService
    {
        Task<IEnumerable<GeocodingDTO>> GetGeocodingsAsync(string searchQuery);
    }
}
