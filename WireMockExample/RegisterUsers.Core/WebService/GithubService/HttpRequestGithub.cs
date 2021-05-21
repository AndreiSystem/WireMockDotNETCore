using System;
using System.Net.Http;
using RegisterUsers.Core.WebService.GithubService.Contracts;

namespace RegisterUsers.Core.WebService.GithubService
{
    public class HttpRequestGithub : IHttpRequestGithub
    {
        public HttpRequestMessage BuildHttpRequestMessage(string queryString)
        {
            return new HttpRequestMessage
            {
                RequestUri = new Uri(new Uri("https://api.github.com/users/"), queryString),
                Method = HttpMethod.Get,
                Headers =
                {
                    {"autorization", "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"},
                    {"User-Agent", "WireMock Integration Tests"}
                }
            };
        }
    }
}