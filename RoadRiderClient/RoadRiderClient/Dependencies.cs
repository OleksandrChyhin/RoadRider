using Microsoft.Extensions.DependencyInjection;
using RoadRiderClient.Core.Settings;

namespace RoadRiderClient
{
    internal static class Dependencies
    {
        public static void RegisterSettings(IServiceCollection services)
        {
            services.AddSingleton<IAppSettings, AppSettings>();
        }
    }
}
