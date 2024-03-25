using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Interfaces;
using Template.Domain.Services;
using Template.Infrastructure.Repositories.HttpClients;
using Template.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Template.Application.Interfaces;
using Template.Application.Business.TestBusiness;
using Template.Infrastructure.Repositories.TestPostgres;
using Template.Domain.Interfaces.Infrastructure;

namespace Template.Application
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClients(configuration);
            services.AddEFContexts(configuration);
            services.AddServices();
            services.AddEFRepositories();
            services.AddApplicationBusiness();
        }

        private static void AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConfiguration("ConnectionStrings:DefaultHttpUrl");
            //https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
            services.AddHttpClient<ITestHttpClient, TestHttpClient>(client =>
            {
                client.BaseAddress = new Uri(connection);
            });
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITestService, TestService>();
        }

        private static void AddApplicationBusiness(this IServiceCollection services)
        {
            services.AddScoped<ITestBusiness, TestBusiness>();
        }

        private static void AddEFRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITestPostgresRepository, TestPostgresRepository>();
        }

        private static void AddEFContexts(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConfiguration("ConnectionStrings:DefaultDbConnection");
            services.AddDbContext<TestContext>(
                options => options.UseNpgsql(connection));
        }

        private static string GetConfiguration(this IConfiguration configuration, string key)
        {
            string? configurationItem = configuration[key];
            if (string.IsNullOrWhiteSpace(configurationItem))
                throw new ArgumentNullException(key, $"Check if the key: '{key}' exists in appsetting.json, and if you're using the right .net environment. =)" +
                    $"\n\nhttps://learn.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-7.0#environments \n\n");

            return configurationItem!;
        }
    }
}
