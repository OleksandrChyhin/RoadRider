using Windows.ApplicationModel.Resources;

namespace RoadRiderClient.Core.Settings
{
    public class AppSettings : IAppSettings
    {
        public AppSettings()
        {
            var resourceLoader = ResourceLoader.GetForCurrentView("appsettings");

            BaseServerUrl = resourceLoader.GetString(nameof(BaseServerUrl));
            MapToken = resourceLoader.GetString(nameof(MapToken));
        }

        public string BaseServerUrl { get; private set; }

        public string MapToken { get; private set; }
    }
}
