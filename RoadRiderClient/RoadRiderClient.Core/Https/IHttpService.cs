using System.Threading.Tasks;

namespace RoadRiderClient.Core.Https
{
    public interface IHttpService
    {
        Task<TResult> GetAsync<TResult>(string urlRequest);
    }
}
