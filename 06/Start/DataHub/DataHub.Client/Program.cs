using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Configuration;
using DataHub.ServiceDefinition; 

string serverAddress = "https://localhost:5001";
GrpcChannel grpcChannel = CreateChannel(serverAddress);
Ingest.IngestClient client = new Ingest.IngestClient(grpcChannel);

RequestSendDataPackage requestSendDataPackage = new RequestSendDataPackage(); 
requestSendDataPackage.TagName = "TagName";
requestSendDataPackage.TelemetryGuid = Guid.NewGuid().ToString();
requestSendDataPackage.TrackingGuid = Guid.NewGuid().ToString();
requestSendDataPackage.TagValue.Add("A01"); 
requestSendDataPackage.TagValue.Add("A02"); 
requestSendDataPackage.TagValue.Add("A03"); 


ResponseSendDataPackage responseSendDataPackage = client.SendDataPackage(requestSendDataPackage);
Console.WriteLine(responseSendDataPackage.DataPackageCount); 


static GrpcChannel CreateChannel(string serverAddress)
{
    var methodConfig = new MethodConfig
    {
        Names = { MethodName.Default },
        RetryPolicy = new RetryPolicy
        {
            MaxAttempts = 5,
            InitialBackoff = TimeSpan.FromSeconds(0.5),
            MaxBackoff = TimeSpan.FromSeconds(2),
            BackoffMultiplier = 1.5,
            RetryableStatusCodes = { StatusCode.Unavailable }
        }
    };

    return GrpcChannel.ForAddress(serverAddress, new GrpcChannelOptions
    {
        ServiceConfig = new ServiceConfig { MethodConfigs = { methodConfig } }
    });
}

