using Microsoft.Extensions.DependencyInjection;
using RoadRiderClient.Core.Builders.ContentDialogs;
using RoadRiderClient.Core.Directors.ContentDialogs;
using RoadRiderClient.Shared;
using RoadRiderClient.ViewModels;
using System;
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
                var geolocator = new Geolocator();
                var position = await geolocator.GetGeopositionAsync();
                var location = position.Coordinate.Point;

                await Map.TrySetSceneAsync(MapScene.CreateFromLocation(location));
                Map.LandmarksVisible = true;
            }
        }

        async void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            try
            {
                if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    await ViewModel.SearchAsync();
                }
            }
            catch (Exception)
            {
                var dialog = ContentDialogDirector.CreateNotificationDialog(Constants.Error.Oops,
                                                                            Constants.Error.DefaultErrorMessage);
                await dialog.ShowAsync();
            }
        }

        async void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            try
            {
                var geopoint = ViewModel.GetLocation(args.QueryText);
                await Map.TrySetSceneAsync(MapScene.CreateFromLocation(geopoint));
            }
            catch (Exception)
            {
                var dialog = ContentDialogDirector.CreateNotificationDialog(Constants.Error.Oops,
                                                                            Constants.Error.DefaultErrorMessage);
                await dialog.ShowAsync();
            }
        }

    }
}
