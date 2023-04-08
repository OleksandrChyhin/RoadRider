using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace RoadRiderClient.Core.Https
{
    public class HttpService : IHttpService, IDisposable
    {
        readonly HttpClient _httpClient;

        public HttpService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<TResult> GetAsync<TResult>(Uri urlRequest)
        {
            var response = await _httpClient.GetAsync(urlRequest);

            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(json);
            }

            return JsonConvert.DeserializeObject<TResult>(json);
        }

        public void Dispose() => _httpClient?.Dispose();
    }
}
