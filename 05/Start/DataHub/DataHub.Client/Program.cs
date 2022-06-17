using DataHub.ServiceDefinition;
using Grpc.Core;
using Grpc.Net.Client; 

string serverAddress = "https://localhost:5001";
GrpcChannel grpcChannel = GrpcChannel.ForAddress(serverAddress);

// Ingest Data 
Ingest.IngestClient ingestClient = new Ingest.IngestClient(grpcChannel);

using var sendDataPackagesStream = ingestClient.SendDataPackagesStream(); 

for (int i=0; i<10; i++)
{
    RequestSendDataPackageStream request = new RequestSendDataPackageStream(){ 

        TrackingGuid = Guid.NewGuid().ToString(),
        TelemetryGuid = Guid.NewGuid().ToString(),
        TagName = "DateTimeTicks",
        TagValue = DateTime.UtcNow.Ticks.ToString()
    };
    try {
        await sendDataPackagesStream.RequestStream.WriteAsync(request);
    } catch (RpcException exc)
    {
        Console.WriteLine(exc.Message);
    }
}

await sendDataPackagesStream.RequestStream.CompleteAsync();
ResponseSendDataPackage response = await sendDataPackagesStream.ResponseAsync;
Console.WriteLine(response.DataPackageCount);


















//Egress Data
Egress.EgressClient egressClient = new Egress.EgressClient(grpcChannel); 
RequestGetDataPackage egressRequest = new RequestGetDataPackage(){
    TagName = "SomeTagName",
    TrackingGuid = Guid.NewGuid().ToString(),
};

CancellationToken cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(60)).Token;
using var dataPackageStream = egressClient.GetDataPackagesStream(egressRequest);
try {
    await foreach(var dataPackage in dataPackageStream.ResponseStream.ReadAllAsync(cancellationToken))
    {
        if (dataPackage.IsSuccess)
        {
            Console.WriteLine($"{dataPackage.TrackingGuid}");
        }
    }
} catch (RpcException exception) {
    Console.WriteLine($"{exception.Message}");
}
