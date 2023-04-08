using Microsoft.Extensions.Configuration;
using RoadRiderAPI.Core.HttpsClientServices;
using RoadRiderAPI.MapboxModels;
using ViewModels;

namespace RoadRiderAPI.Core.MapboxAPIs.Geocodings
{
    public class GeocodingService : MapboxBase, IGeocodingService
    {
        public GeocodingService(IConfiguration configuration, IHttpClientService httpClientService) : base(configuration, httpClientService)
        { }

        protected override string APIName => "geocoding/v5";

        string Endpoint => "mapbox.places";

        public async Task<IEnumerable<GeocodingOutputModel>> ForwardGeocoding(string search/*, bool autocomplete = false, string language = "us", int limit = 7*/)
        {
            //"https://api.mapbox.com/geocoding/v5/mapbox.places/Odes.json?access_token={accessToken}"

            //var queryParams = new[] {$"{search}.json",TokenParameter};
            //var querry = string.Join("/", queryParams);
            //var uriBuilder = new UriBuilder(BaseUrl) {Query = querry};
            var url = $"{BaseUrl}{Endpoint}/{search}.json{TokenParameter}";
            var result = await _httpClientService.GetAsync<GeocodingResponseObject>(url);
            return result.Features.Select(x => MapToGeocodingOutputModel(x));
        }

        public async Task ReverseGeocoding((double, double) search/*, string language ="u s", int limit = 5*/)
        {
            var url = $"{_defaultUrl}/{APIName}{Endpoint}/{search.Item1},{search.Item2}.json{TokenParameter}";
            await _httpClientService.GetAsync<string>(url);
        }

        GeocodingOutputModel MapToGeocodingOutputModel(GeocodingDTO geocodingDTO)
        {
            var longtityde = geocodingDTO.Geometry.Coordinates[0];
            var latitude = geocodingDTO.Geometry.Coordinates[1];
            var geocodingOutputModel = new GeocodingOutputModel
            {
                Id = geocodingDTO.Id,
                Type = geocodingDTO.Type,
                PlaceType = geocodingDTO.PlaceType,
                Relevance = geocodingDTO.Relevance,
                PlaceName = geocodingDTO.PlaceName,
                Coordinates = new PointDTO
                {
                    Longtitude = longtityde,
                    Latitude = latitude
                },
                Address = geocodingDTO.Properties.Address
            };
            return geocodingOutputModel;
        }


    }
}
