using Grpc.Core;
using Grpc.Net.Client;
using MagicOnion.Client;
using MoShared;
using System.Threading.Channels;

namespace MOClient
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            Thread.Sleep(5000);
            // Connect to the server using gRPC channel.
            //var channel = GrpcChannel.ForAddress("https://localhost:5225");

            // NOTE: If your project targets non-.NET Standard 2.1, use `Grpc.Core.Channel` class instead.
            // var channel = new Channel("localhost", 5001, new SslCredentials());
            var channel = new Grpc.Core.Channel("localhost", 5225, new SslCredentials());

            // Create a proxy to call the server transparently.
            var client = MagicOnionClient.Create<IMyFirstService>(channel);

            // Call the server-side method using the proxy.
            var result = await client.SumAsync(123, 456);
            Console.WriteLine($"Result: {result}");
        }
    }
}