using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Serialization;
using RoadRiderAPI.Core.HttpsClientServices;

namespace RoadRiderAPI.Core.MapboxAPIs
{
    public abstract class MapboxBase
    {
        protected readonly string _token;
        protected readonly string _defaultUrl;
        protected readonly IHttpClientService _httpClientService;

        protected virtual string BaseUrl => $"{_defaultUrl}/{APIName}/";
        protected string TokenParameter => $"?access_token={_token}";
        protected abstract string APIName { get; }

        public MapboxBase(IConfiguration configuration, IHttpClientService httpClientService)
        {
            _token = configuration.GetSection("MapboxSettings:Token").Value;
            _defaultUrl = configuration.GetSection("MapboxSettings:DefaultAddress").Value;
            _httpClientService = httpClientService;
            _httpClientService.ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
        }
    }
}
