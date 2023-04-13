using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceModelServer;

namespace GrpcCandidate
{
    internal class Program
    {
        public static Task Main(string[] args)
        {
            return Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(services => services.AddHostedService<ServerHost>())
            .Build()
            .RunAsync();
        }
    }
}   