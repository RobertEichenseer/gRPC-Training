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
}
