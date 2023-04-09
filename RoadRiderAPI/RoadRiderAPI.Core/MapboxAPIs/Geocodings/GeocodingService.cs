using Microsoft.Extensions.Configuration;
using RoadRiderAPI.Core.HttpsClientServices;
using RoadRiderAPI.MapboxModels.Geocoding;
using ViewModels;

namespace RoadRiderAPI.Core.MapboxAPIs.Geocodings
{
    public class GeocodingService : MapboxBase, IGeocodingService
    {
        public GeocodingService(IConfiguration configuration, IHttpClientService httpClientService) : base(configuration, httpClientService)
        { }

        protected override string APIName => "geocoding/v5";

        string Endpoint => "mapbox.places";

        public async Task<IEnumerable<GeocodingOutputModel>> ForwardGeocodingAsync(string search/*, bool autocomplete = false, string language = "us", int limit = 7*/)
        {
            var url = $"{BaseUrl}{Endpoint}/{search}.json{TokenParameter}&language=en";
            var result = await _httpClientService.GetAsync<GeocodingResponseObject>(url);
            return result.Features.Select(x => MapToGeocodingOutputModel(x));
        }

        public async Task<IEnumerable<GeocodingOutputModel>> GetGeolocationByPlacementTypeAsync(string search, double latitude, double longtitude, string type, int limit)
        {
            var url = $"{BaseUrl}{Endpoint}/{search}.json{TokenParameter}&type={type}&proximity={longtitude:#.000},{latitude:#.000}&{limit}";
            var result = await _httpClientService.GetAsync<GeocodingResponseObject>(url);
            return result.Features.Where(x => x.PlaceType.Contains(type)).Select(x => MapToGeocodingOutputModel(x));
        }        

        public async Task<GeocodingOutputModel> ReverseGeocodingAsync(double latitude, double longtitude /*, string language ="u s", int limit = 5*/)
        {
            var url = $"{BaseUrl}{Endpoint}/{longtitude:#.000},{latitude:#.000}.json{TokenParameter}";
            var result = await _httpClientService.GetAsync<GeocodingResponseObject>(url);
            return result.Features.Select(x => MapToGeocodingOutputModel(x)).First();
        }

        GeocodingOutputModel MapToGeocodingOutputModel(GeocodingDTO geocodingDTO)
        {
            var longtitude = geocodingDTO.Geometry.Coordinates.ElementAt(0);
            var latitude = geocodingDTO.Geometry.Coordinates.ElementAt(1);
            var geocodingOutputModel = new GeocodingOutputModel
            {
                Id = geocodingDTO.Id,
                Type = geocodingDTO.Type,
                PlaceType = geocodingDTO.PlaceType,
                Relevance = geocodingDTO.Relevance,
                PlaceName = geocodingDTO.PlaceName,
                Text = geocodingDTO.Text,
                Category = geocodingDTO.Properties.Category,
                Coordinates = new PointDTO
                {
                    Latitude = latitude,
                    Longtitude = longtitude
                },
                Address = geocodingDTO.Properties.Address
            };
            return geocodingOutputModel;
        }


    }
}
