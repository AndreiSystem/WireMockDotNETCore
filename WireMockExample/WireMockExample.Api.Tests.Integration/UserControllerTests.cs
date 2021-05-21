using System.Net.Http;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using RegisterUsers.Core.Domain.Entities;
using RegisterUsers.Core.WebService;
using RegisterUsers.Core.WebService.GithubService;
using RegisterUsers.Core.WebService.GithubService.Contracts;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace WireMockExample.Api.Tests.Integration
{
    public class UserControllerTests
    {
        private readonly WireMockServer _server;
        private readonly IGithub _github;
        private readonly IHttpRequestGithub _httpRequestGithub;
        private readonly IGithubHttpClient _githubHttpClient;

        public UserControllerTests()
        {
            _server = WireMockServer.Start();

            _httpRequestGithub = Substitute.For<IHttpRequestGithub>();
            _githubHttpClient = Substitute.For<IGithubHttpClient>();
            _github = new Github(_httpRequestGithub, _githubHttpClient);
        }
        
        [Fact]
        public async void GetUser_Should_Return_User_When_Exists()
        {
            var userResponse = Builder<User>.CreateNew()
                .With(u => u.Name = "Andrei Gustavo Teixeira Da Luz")
                .With(u => u.Url = "github.com")
                .Build();
                
            
            _server
                .Given(Request.Create().WithPath("/AndreiSystem")
                    .UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(userResponse)
                );

            var queryString = Builder<QueryStringGithubUser>.CreateNew()
                .With(q => q.UserName = "AndreiSystem")
                .Build();
            
            var user = await _github.GetUser(queryString);


            user.Name.Should().Be(userResponse.Name);
            user.Url.Should().Be(userResponse.Url);
        }
    }
}