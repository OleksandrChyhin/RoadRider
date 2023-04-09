using RoadRiderClient.Core.ProviderServices.Geocodings;
using RoadRiderClient.Core.Settings;
using RoadRiderClient.Models;
using RoadRiderClient.Shared.Extensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI.Xaml.Controls.Maps;

namespace RoadRiderClient.ViewModels
{
    public class MapViewModel : ViewModelBase
    {
        string _poiSearchQuery;
        string _citySearchQuery;
        GeocodingDTO _selectedPoi;
        Geopoint _geopoint;
        readonly IGeocodingsProviderService _geocodingsProviderService;

        IDictionary<string, GeocodingDTO> SearchGeocodings { get; set; }

        public MapViewModel(IAppSettings appSettings,
                            IGeocodingsProviderService geocodingsProviderService)
        {
            MapToken = appSettings.MapToken;
            _geocodingsProviderService = geocodingsProviderService;

            CitySearchSuggestions = new ObservableCollection<string>();
            Pois = new ObservableCollection<GeocodingDTO>();
        }

        public string MapToken { get; private set; }

        public string PoiSearcQuery
        {
            get => _poiSearchQuery;
            set => SetProperty(ref _poiSearchQuery, value);
        }

        public string CitySearchQuery
        {
            get => _citySearchQuery;
            set
            {
                SetProperty(ref _citySearchQuery, value);
                PoiSearcQuery = string.Empty;
                Pois.Clear();
                SelectedPoi = null;
            }
        }

        public GeocodingDTO SelectedPoi
        {
            get => _selectedPoi;
            set => SetProperty(ref _selectedPoi, value);
        }

        public Geopoint Geopoint
        {
            get => _geopoint;
            set => SetProperty(ref _geopoint, value);
        }

        public ICollection<string> CitySearchSuggestions { get; private set; }
        public ICollection<GeocodingDTO> Pois { get; private set; }

        public async Task SearchPlacesAsync()
        {
            if (string.IsNullOrEmpty(CitySearchQuery))
            {
                return;
            }

            var geocodings = CitySearchQuery.HasCooridnates()
                ? await _geocodingsProviderService.GetReverseGeocodingAsync(CitySearchQuery)
                : await _geocodingsProviderService.GetForwardGeocodingAsync(CitySearchQuery);

            SearchGeocodings = geocodings.ToDictionary(x => x.PlaceName, x => x);

            CitySearchSuggestions.Clear();
            CitySearchSuggestions.AddRange(SearchGeocodings.Select(x => x.Key));
        }

        public Geopoint GetLocation(string location)
        {
            if (string.IsNullOrEmpty(location))
            {
                return null;
            }

            var geocoding = SearchGeocodings[location];
            return new Geopoint(new BasicGeoposition
            {
                Latitude = geocoding.Coordinates.Latitude,
                Longitude = geocoding.Coordinates.Longtitude
            });
        }

        public Geopoint GetPoi()
        {
            if (SelectedPoi == null)
            {
                return null;
            }

            return new Geopoint(new BasicGeoposition
            {
                Latitude = SelectedPoi.Coordinates.Latitude,
                Longitude = SelectedPoi.Coordinates.Longtitude
            });
        }

        public async Task<IEnumerable<MapLayer>> GetGeolocationByPlacementAsync()
        {
            if (string.IsNullOrEmpty(PoiSearcQuery))
            {
                return Enumerable.Empty<MapLayer>();
            }

            var pois = await _geocodingsProviderService.GetGeolocationByPlacementType(PoiSearcQuery, Geopoint.Position.Latitude, Geopoint.Position.Longitude, "poi");

            Pois.Clear();
            Pois.AddRange(pois);

            return pois.Select(x =>
            {
                var position = new BasicGeoposition
                {
                    Latitude = x.Coordinates.Latitude,
                    Longitude = x.Coordinates.Longtitude
                };
                var geopoint = new Geopoint(position);

                var icon = new MapIcon
                {
                    Location = geopoint,
                    NormalizedAnchorPoint = new Point(0.5, 1.0),
                    ZIndex = 0,
                    Title = x.Text
                };

                return new MapElementsLayer
                {
                    ZIndex = 1,
                    MapElements = new List<MapElement> { icon }
                };
            });
        }
    }
}
