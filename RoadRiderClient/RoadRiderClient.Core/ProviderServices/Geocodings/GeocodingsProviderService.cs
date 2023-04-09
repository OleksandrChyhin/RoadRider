using RoadRiderClient.Core.Https;
using RoadRiderClient.Core.Settings;
using RoadRiderClient.Models;
using RoadRiderClient.Shared.Extensions;
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

        public async Task<IEnumerable<GeocodingDTO>> GetForwardGeocodingAsync(string searchQuery)
        {
            var builder = new UriBuilder($"{Url}/ForwardGeocoding")
            {
                Query = $"query={searchQuery}"
            };

            return await _httpService.GetAsync<IEnumerable<GeocodingDTO>>(builder.Uri);
        }

        public async Task<IEnumerable<GeocodingDTO>> GetReverseGeocodingAsync(string searchQuery)
        {
            var (lat, @long) = searchQuery.GetCoord();
            var @params = new[]
            {
                $"latitude={lat}",
                $"longtitude={@long}",
            };

            var builder = new UriBuilder($"{Url}/ReverseGeocoding")
            {
                Query = string.Join("&", @params)
            };

            var geocoding = await _httpService.GetAsync<GeocodingDTO>(builder.Uri);
            return new[] { geocoding };
        }
    }
}
