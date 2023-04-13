using Grpc.Core;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceModel.Grpc.Configuration;

namespace ServiceModelServer
{
    internal class ServerHost : IHostedService
    {
        private readonly Server _server;
        private int SelfHostPort = 7000;

        public ServerHost()
        {
            _server = new Server
            {
                Ports =
            {
                new ServerPort("localhost", SelfHostPort, ServerCredentials.Insecure)
            }
            };

            _server.Services.AddServiceModelSingleton(
                new CwnetService(),
                options =>
                {
                    // set ProtobufMarshaller as default Marshaller
                    options.MarshallerFactory = ProtobufMarshallerFactory.Default;
                });
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _server.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => _server.ShutdownAsync();
    }
}
