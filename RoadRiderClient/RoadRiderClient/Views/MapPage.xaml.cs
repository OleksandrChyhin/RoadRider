using Microsoft.Extensions.DependencyInjection;
using RoadRiderClient.Core.Builders.ContentDialogs;
using RoadRiderClient.Core.Directors.ContentDialogs;
using RoadRiderClient.Shared;
using RoadRiderClient.Shared.Extensions;
using RoadRiderClient.ViewModels;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RoadRiderClient.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        MapViewModel ViewModel { get; set; }
        IContentDialogDirector ContentDialogDirector { get; set; }
        DispatcherTimer _dispatcherTimer;

        public MapPage()
        {
            InitializeComponent();

            var container = (Application.Current as App).Container;

            ViewModel = container.GetRequiredService<MapViewModel>();
            ContentDialogDirector = container.GetRequiredService<IContentDialogDirector>();
            ContentDialogDirector.Builder = container.GetRequiredService<IContentDialogBuilder>();
        }

        async void Map_Loading(FrameworkElement sender, object args)
        {
            if (await Geolocator.RequestAccessAsync() == GeolocationAccessStatus.Allowed)
            {
                await CreateMapIconAsync();
            }
        }

        async void CityAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            try
            {
                if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    var startLength = sender.Text.Length;

                    await Task.Delay(300);
                    if (startLength == sender.Text.Length)
                    {
                        await ViewModel.SearchPlacesAsync();
                    }
                }
            }
            catch (Exception)
            {
                var dialog = ContentDialogDirector.CreateNotificationDialog(Constants.Error.Oops,
                                                                            Constants.Error.DefaultErrorMessage);
                await dialog.ShowAsync();
            }
        }

        async void CityAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            try
            {
                var geopoint = ViewModel.GetLocation(args.QueryText);
                if (geopoint != null)
                {
                    await Map.TrySetSceneAsync(MapScene.CreateFromLocation(geopoint));
                }
            }
            catch (Exception)
            {
                var dialog = ContentDialogDirector.CreateNotificationDialog(Constants.Error.Oops,
                                                                            Constants.Error.DefaultErrorMessage);
                await dialog.ShowAsync();
            }
        }

        async void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            try
            {
                var startLength = sender.Text.Length;

                await Task.Delay(300);
                if (startLength == sender.Text.Length)
                {
                    var layers = await ViewModel.GetGeolocationByPlacementAsync();

                    Map.Layers.Clear();
                    Map.Layers.AddRange(layers);
                }
            }
            catch (Exception)
            {
                var dialog = ContentDialogDirector.CreateNotificationDialog(Constants.Error.Oops,
                                                                            Constants.Error.DefaultErrorMessage);
                await dialog.ShowAsync();
            }

        }

        async void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (await Geolocator.RequestAccessAsync() == GeolocationAccessStatus.Allowed)
            {
                try
                {
                    var poi = ViewModel.GetPoi();
                    if (poi != null)
                    {
                        await Map.TrySetSceneAsync(MapScene.CreateFromLocation(poi));
                    }
                }
                catch (Exception)
                {
                    var dialog = ContentDialogDirector.CreateNotificationDialog(Constants.Error.Oops,
                                                                                Constants.Error.DefaultErrorMessage);
                    await dialog.ShowAsync();
                }
            }
        }

        async Task CreateMapIconAsync()
        {
            var geolocator = new Geolocator();
            var position = await geolocator.GetGeopositionAsync();
            var location = position.Coordinate.Point;

            var mapIcon = new MapIcon
            {
                Title = ResourceLoader.GetForCurrentView().GetString(Constants.You),
                Location = location
            };
            Map.MapElements.Add(mapIcon);

            await Map.TrySetSceneAsync(MapScene.CreateFromLocation(location));
        }
    }
}
