using Microsoft.Extensions.DependencyInjection;
using RoadRiderClient.Core.Builders.ContentDialogs;
using RoadRiderClient.Core.Directors.ContentDialogs;
using RoadRiderClient.Core.Https;
using RoadRiderClient.Core.ProviderServices.Geocodings;
using RoadRiderClient.Core.Settings;
using RoadRiderClient.ViewModels;

namespace RoadRiderClient
{
    internal static class Dependencies
    {
        public static void RegisterViewModels(IServiceCollection services)
        {
            services.AddScoped<MainPageViewModel>()
                    .AddScoped<MapViewModel>();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IHttpService, HttpService>();

            services.AddScoped<IGeocodingsProviderService, GeocodingsProviderService>();
        }

        public static void RegisterBuildersAndDirectors(IServiceCollection services)
        {
            services.AddScoped<IContentDialogBuilder, ContentDialogBuilder>()
                    .AddScoped<IContentDialogDirector, ContentDialogDirector>();
        }

        public static void RegisterSettings(IServiceCollection services)
        {
            services.AddSingleton<IAppSettings, AppSettings>();
        }
    }
}
