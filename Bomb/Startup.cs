using Bomb.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Bomb
{
    public class Startup : IStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDependencyInjectionConfiguration();
            services.AddDatabaseConfiguration(configuration);
        }
    }

    public interface IStartup
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }

    public static class StartupExtensions
    {
        public static IHost UseStartup<TStartup>(this IHostBuilder hostBuilder) where TStartup : IStartup
        {
            IConfiguration config = new ConfigurationBuilder().Build();

            hostBuilder
                .ConfigureAppConfiguration((hostingContext, configBuilder) =>
                {
                    configBuilder.Sources.Clear();

                    config = configBuilder
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", false, true)
                        .Build();
                })
                .ConfigureLogging((context, logging) => 
                {
                    logging.SetMinimumLevel(LogLevel.Warning);
                });

            var startup = Activator.CreateInstance(typeof(TStartup)) as IStartup;
            if (startup == null) throw new ArgumentException("Classe Startup.cs inválida!");

            hostBuilder.ConfigureServices((hostBuilder, services) => startup.ConfigureServices(services, hostBuilder.Configuration));
            var app = hostBuilder.Build();

            return app;
        }
    }
}
