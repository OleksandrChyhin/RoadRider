using Newtonsoft.Json.Serialization;

namespace RoadRiderAPI.Core.HttpsClientServices
{
    public interface IHttpClientService
    {
        DefaultContractResolver ContractResolver { get; set; }

        Task<TResult> GetAsync<TResult>(string urlRequest);
        Task<TResult> GetAsync<TResult>(Uri uri);
    }
}
