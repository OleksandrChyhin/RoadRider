using Microsoft.Extensions.DependencyInjection;
using RoadRiderClient.Core.Https;
using RoadRiderClient.Core.Settings;
using RoadRiderClient.ViewModels;

namespace RoadRiderClient
{
    internal static class Dependencies
    {
        public static void RegisterViewModels(IServiceCollection services)
        {
            services.AddScoped<MainPageViewModel>();
            services.AddScoped<MapViewModel>();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IHttpService, HttpService>();
        }

        public static void RegisterSettings(IServiceCollection services)
        {
            services.AddSingleton<IAppSettings, AppSettings>();
        }
    }
}
