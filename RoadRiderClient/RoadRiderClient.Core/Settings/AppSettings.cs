using Windows.ApplicationModel.Resources;

namespace RoadRiderClient.Core.Settings
{
    public class AppSettings : IAppSettings
    {
        public AppSettings()
        {
            var resourceLoader = ResourceLoader.GetForCurrentView("appsettings");

            BaseServerUrl = resourceLoader.GetString(nameof(BaseServerUrl));
        }

        public string BaseServerUrl { get; private set; }
    }
}
