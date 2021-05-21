using System.Net.Http;

namespace RegisterUsers.Core.WebService.GithubService.Contracts
{
    public interface IHttpRequestGithub
    {
        HttpRequestMessage BuildHttpRequestMessage(string queryString);
    }
}