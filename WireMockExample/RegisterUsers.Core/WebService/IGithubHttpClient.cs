using System.Net.Http;
using System.Threading.Tasks;

namespace RegisterUsers.Core.WebService
{
    public interface IGithubHttpClient
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage);
    }
}