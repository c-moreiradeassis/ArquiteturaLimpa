using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ArquiteturaLimpa.Servico
{
    class Program
    {
        static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, configuration) =>
            {
                configuration.Sources.Clear();

                IHostEnvironment env = hostingContext.HostingEnvironment;

                configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            })
            .ConfigureServices((_, services) =>
            services.AddHostedService<Processador>());
    }
}
