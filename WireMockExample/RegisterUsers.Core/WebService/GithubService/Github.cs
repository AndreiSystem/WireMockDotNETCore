using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RegisterUsers.Core.Domain.Entities;
using RegisterUsers.Core.WebService.Commons;
using RegisterUsers.Core.WebService.GithubService.Contracts;

namespace RegisterUsers.Core.WebService.GithubService
{
    public class Github : IGithub
    {
        private readonly IHttpRequestGithub _httpRequestGithub;
        private readonly IGithubHttpClient _githubHttpClient;
        
        public Github(IHttpRequestGithub httpRequestGithub, IGithubHttpClient githubHttpClient)
        {
            _httpRequestGithub = httpRequestGithub;
            _githubHttpClient = githubHttpClient;
        }
        public async Task<User> GetUser(QueryStringGithubUser queryStringGithubUser)
        {
            var httpRequestMessage = _httpRequestGithub.BuildHttpRequestMessage(queryStringGithubUser.UserName);
            HttpResponseMessage httpRequestResponse;

            try
            {
                httpRequestResponse = await _githubHttpClient.SendAsync(httpRequestMessage);
            
                var user = await httpRequestResponse.Content.ReadFromJsonAsync<User>();

                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}