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

        public async Task<TResult> GetAsync<TResult>(string urlRequest)
        {
            var response = await _httpClient.GetAsync(new Uri(urlRequest));
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ToString());
            }

            return await ConvertResponseContent<TResult>(response.Content);
        }

        public void Dispose() => _httpClient?.Dispose();

        protected async virtual Task<TResult> ConvertResponseContent<TResult>(IHttpContent content)
        {
            var json = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(json);
        }
    }
}
