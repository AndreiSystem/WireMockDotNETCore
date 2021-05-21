using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace RegisterUsers.Core.WebService
{
    public class GithubHttpClient : IGithubHttpClient
    {
        private readonly HttpClient _httpClient;
        public GithubHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            var sw = new Stopwatch();
            sw.Start();

            var result = await _httpClient.SendAsync(httpRequestMessage);
            sw.Stop();

            return result;

        }
    }
}