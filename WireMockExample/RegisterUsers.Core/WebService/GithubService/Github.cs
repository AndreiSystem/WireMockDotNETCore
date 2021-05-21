using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RegisterUsers.Core.Domain.Entities;
using RegisterUsers.Core.WebService.Commons;
using RegisterUsers.Core.WebService.GithubService.Contracts;

namespace RegisterUsers.Core.WebService.GithubService
{
    public class Github : IGithub
    {
        private readonly IUriQueryFactory _uriQueryFactory;
        private readonly IHttpRequestGithub _httpRequestGithub;
        private readonly IGithubHttpClient _githubHttpClient;
        
        public Github(IUriQueryFactory uriQueryFactory, IHttpRequestGithub httpRequestGithub, IGithubHttpClient githubHttpClient)
        {
            _uriQueryFactory = uriQueryFactory;
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            var json = await httpRequestResponse.Content.ReadAsStringAsync();

            try
            {
                var user = JsonConvert.DeserializeObject<User>(json);

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