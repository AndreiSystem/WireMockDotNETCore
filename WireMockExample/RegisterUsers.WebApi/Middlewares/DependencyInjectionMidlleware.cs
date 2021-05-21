using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegisterUsers.Core.Domain.Entities;
using RegisterUsers.Core.Repository;
using RegisterUsers.Core.Repository.Context;
using RegisterUsers.Core.Repository.Interfaces;
using RegisterUsers.Core.Services;
using RegisterUsers.Core.Services.Interfaces;
using RegisterUsers.Core.Settings;
using RegisterUsers.Core.WebService;
using RegisterUsers.Core.WebService.Commons;
using RegisterUsers.Core.WebService.GithubService;
using RegisterUsers.Core.WebService.GithubService.Contracts;

namespace RegisterUsers.WebApi.Middlewares
{
    public static class DependencyInjectionMidlleware
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoDbSettings = configuration.GetSection("MongoDBSetting").Get<MongoDbSetting>();

            var connectionFactory = new ConnectionFactory(mongoDbSettings.ConnectionString);

            services.AddSingleton<IRepository<User>>(
                u => new UserRepository(connectionFactory, mongoDbSettings.DatabaseName,
                    mongoDbSettings.CollectionName));

            services.AddTransient<IUserServices, UserServices>();
            services.AddScoped<IGithub, Github>();
            services.AddScoped<IGithubHttpClient, GithubHttpClient>();
            services.AddScoped<IHttpRequestGithub, HttpRequestGithub>();
            services.AddScoped<IUriQueryFactory, UriQueryFactory>();
            services.AddHttpClient<IGithubHttpClient, GithubHttpClient>();
        }
    }
}