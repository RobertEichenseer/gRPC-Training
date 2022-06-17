using Grpc.Core;
using DataHub.Server;
using DataHub.ServiceDefinition;

namespace DataHub.Server.Services;

public class IngestService : Ingest.IngestBase
{
    private readonly ILogger<IngestService> _logger;
    public IngestService(ILogger<IngestService> logger)
    {
        _logger = logger;
    }

    public override Task<ResponseSendDataPackage> SendDataPackage(RequestSendDataPackage request, ServerCallContext context)
    {
        
        return Task.FromResult(new ResponseSendDataPackage()
        {
            DataPackageCount = (int)request.TagValue.Count, 
            IsSuccess = true,
            LastError = "",
            TrackingGuid = Guid.NewGuid().ToString()
        });
    }

    //External Counter Storage needed - static class variable not appropriate - just for demo purpose
    private static int _packageCounter = 0; 
    public override async Task<ResponseSendDataPackage> SendDataPackagesStream (IAsyncStreamReader<RequestSendDataPackageStream> request, ServerCallContext context) 
    {
        while (await request.MoveNext())
        {
            RequestSendDataPackageStream dataPackage = request.Current;
            string msg = $"Data Package: {dataPackage.TelemetryGuid} arrived!";
            _logger.LogTrace(msg);
            _packageCounter ++; 
        }
 
        return new ResponseSendDataPackage(){
            IsSuccess = true,
            LastError = "",
            DataPackageCount = _packageCounter,
        };         
    }        

    
}
