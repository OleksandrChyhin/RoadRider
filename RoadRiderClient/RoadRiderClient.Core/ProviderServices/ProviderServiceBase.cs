using RoadRiderClient.Core.Https;
using RoadRiderClient.Core.Settings;

namespace RoadRiderClient.Core.ProviderServices
{
    public abstract class ProviderServiceBase
    {
        protected readonly string _baseUrl;
        protected readonly IHttpService _httpService;

        protected abstract string Endpoint { get; }

        protected virtual string Url => $"{_baseUrl}/api/{Endpoint}";

        public ProviderServiceBase(IHttpService httpService, IAppSettings appSettings)
        {
            _httpService = httpService;

            _baseUrl = appSettings.BaseServerUrl;
        }
    }
}
