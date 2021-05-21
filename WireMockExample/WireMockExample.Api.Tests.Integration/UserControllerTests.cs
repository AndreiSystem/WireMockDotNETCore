using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using RegisterUsers.Core.Domain.Entities;
using RegisterUsers.Core.WebService;
using RegisterUsers.Core.WebService.GithubService;
using RegisterUsers.Core.WebService.GithubService.Contracts;
using RegisterUsers.WebApi;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace WireMockExample.Api.Tests.Integration
{
    public class UserControllerTests
    {
        private readonly WireMockServer _wireMockServer;
        public UserControllerTests()
        {
            _wireMockServer = WireMockServer.Start();
        }

        [Fact]
        public async void GetUser_Should_Return_User_When_Exists()
        {
            var expectedUser = Builder<User>.CreateNew()
                .With(u => u.Name = "Andrei Gustavo Teixeira Da Luz")
                .With(u => u.Url = "https://api.github.com/users/AndreiSystem")
                .Build();
            
            _wireMockServer
                .Given(Request.Create().WithPath("/AndreiSystem")
                    .UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(expectedUser)
                );
            var response = await new HttpClient().GetAsync($"{_wireMockServer.Urls[0]}/AndreiSystem");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseObject = await response.Content.ReadFromJsonAsync<User>();
            
            responseObject.Name.Should().Be(expectedUser.Name);
        }
    }
}