using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MOService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var builder = WebApplication.CreateBuilder(args);
             var app = builder.Build();
             app.MapMagicOnionService();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)

            .ConfigureServices((hostContext, services) =>
            {
                services.AddGrpc();
                services.AddMagicOnion();

                // services.AddHostedService<Worker>();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                
                webBuilder.UseStartup<Startup>();
                // webBuilder.UseKestrel(o => o.ListenLocalhost(ServiceConfiguration.AspNetCorePort, l => l.Protocols = HttpProtocols.Http2));
            })
        .ConfigureServices(services => services.AddSingleton<Executor>());
    }
    public class Executor
    {
        private readonly object _test;

        public Executor(object test)
        {
            _test = test;
        }

        public void Execute()
        {
            //_test.DoSomething();
        }
    }
}