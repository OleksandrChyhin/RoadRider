using Microsoft.Extensions.DependencyInjection;
using RoadRiderClient.Core.Settings;
using RoadRiderClient.ViewModels;

namespace RoadRiderClient
{
    internal static class Dependencies
    {
        public static void RegisterViewModels(IServiceCollection services)
        {
            services.AddScoped<MainPageViewModel>();
        }

        public static void RegisterSettings(IServiceCollection services)
        {
            services.AddSingleton<IAppSettings, AppSettings>();
        }
    }
}
