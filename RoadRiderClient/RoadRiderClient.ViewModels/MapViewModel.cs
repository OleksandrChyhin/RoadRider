using RoadRiderClient.Core.ProviderServices.Geocodings;
using RoadRiderClient.Core.Settings;
using RoadRiderClient.Models;
using RoadRiderClient.Shared.Extensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace RoadRiderClient.ViewModels
{
    public class MapViewModel : ViewModelBase
    {
        string _searchQuery;
        GeocodingDTO _selectedGeocoding;
        readonly IGeocodingsProviderService _geocodingsProviderService;

        public MapViewModel(IAppSettings appSettings,
                            IGeocodingsProviderService geocodingsProviderService)
        {
            MapToken = appSettings.MapToken;
            _geocodingsProviderService = geocodingsProviderService;

            Suggestions = new ObservableCollection<string>();
        }

        public string MapToken { get; private set; }

        public string SearchQuery
        {
            get => _searchQuery;
            set => SetProperty(ref _searchQuery, value);
        }

        public GeocodingDTO SelectedGeocoding
        {
            get => _selectedGeocoding;
            set => SetProperty(ref _selectedGeocoding, value);
        }

        public ICollection<string> Suggestions { get; private set; }
        IDictionary<string, GeocodingDTO> Geocodings { get; set; }


        public async Task SearchAsync()
        {
            if (string.IsNullOrEmpty(SearchQuery))
            {
                return;
            }

            var hasCoord = SearchQuery.HasCooridnates();

            var geocodings = hasCoord 
                ? await _geocodingsProviderService.GetReverseGeocodingAsync(SearchQuery)
                : await _geocodingsProviderService.GetForwardGeocodingAsync(SearchQuery);

            Suggestions.Clear();
            Suggestions.AddRange(geocodings.Select(x => x.PlaceName));

            Geocodings = geocodings.ToDictionary(x => x.PlaceName, x => x);
        }

        public Geopoint GetLocation(string location)
        {
            var geocoding = Geocodings[location];

            SelectedGeocoding = geocoding;

            return new Geopoint(new BasicGeoposition
            {
                Latitude = geocoding.Coordinates.Latitude,
                Longitude = geocoding.Coordinates.Longtitude
            });
        }
    }
}
