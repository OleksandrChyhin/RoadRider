using RoadRiderAPI.Core.HttpsClientServices;
using RoadRiderAPI.Core.MapboxAPIs.Geocodings;

namespace RoadRiderAPI
{
    public static class Dependencies
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IHttpClientService, HttpClientService>();
            services.AddHttpClient();
            services.AddScoped<IGeocodingService, GeocodingService>();
        }

    }
}
