using System;
using System.Net.Http;
using RegisterUsers.Core.Settings;
using RegisterUsers.Core.WebService.GithubService.Contracts;

namespace RegisterUsers.Core.WebService.GithubService
{
    public class HttpRequestGithub : IHttpRequestGithub
    {
        public HttpRequestMessage BuildHttpRequestMessage(string queryString)
        {
            return new HttpRequestMessage
            {
                RequestUri = new Uri(new Uri(EnvironmentVariablesGithubApi.GithubUri), queryString),
                Method = HttpMethod.Get,
                Headers =
                {
                    {"autorization", EnvironmentVariablesGithubApi.GithubAuth},
                    {"User-Agent", "WireMock Integration Tests"}
                }
            };
        }
    }
}