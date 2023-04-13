using ServiceModel.Grpc.DesignTime;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModelClient
{
    [ImportGrpcService(typeof(ICwnetService))]
    internal static partial class ServiceImport
    {
    }
}
