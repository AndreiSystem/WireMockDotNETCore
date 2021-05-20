using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegisterUsers.Core.Domain.Entities;
using RegisterUsers.Core.Repository;
using RegisterUsers.Core.Repository.Context;
using RegisterUsers.Core.Repository.Intefaces;
using RegisterUsers.Core.Services;
using RegisterUsers.Core.Services.Interfaces;
using RegisterUsers.Core.Settings;

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
        }
    }
}