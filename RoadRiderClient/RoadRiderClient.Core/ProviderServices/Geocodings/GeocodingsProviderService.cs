using RoadRiderClient.Core.Https;
using RoadRiderClient.Core.Settings;
using RoadRiderClient.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoadRiderClient.Core.ProviderServices.Geocodings
{
    public class GeocodingsProviderService : ProviderServiceBase, IGeocodingsProviderService
    {
        public GeocodingsProviderService(IHttpService httpService, IAppSettings appSettings) : base(httpService, appSettings)
        {

        }

        protected override string Endpoint => "Geocodings";

        public async Task<IEnumerable<GeocodingDTO>> GetGeocodingsAsync(string searchQuery)
        {
            var builder = new UriBuilder($"{Url}/ForwardGeocoding")
            {
                Query = $"query={searchQuery}"
            };

            return await _httpService.GetAsync<IEnumerable<GeocodingDTO>>(builder.Uri);
        }
    }
}
