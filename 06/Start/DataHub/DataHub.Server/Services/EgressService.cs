using Grpc.Core;
using DataHub.Server;
using DataHub.ServiceDefinition;

namespace DataHub.Server.Services;

public class EgressService : Egress.EgressBase
{
    private readonly ILogger<IngestService> _logger;
    public EgressService(ILogger<IngestService> logger)
    {
        _logger = logger;
    }

    public override async Task GetDataPackagesStream(RequestGetDataPackage request, IServerStreamWriter<ResponseGetDataPackageStream> responseStream, ServerCallContext context )
    {
        while (!context.CancellationToken.IsCancellationRequested)
        {
            ResponseGetDataPackageStream response = new ResponseGetDataPackageStream() {
                IsSuccess = true,
                LastError = "",
                TrackingGuid = request.TrackingGuid, 
                TagName = request.TagName, 
                TagValue = DateTime.UtcNow.Ticks.ToString()
            };
            await responseStream.WriteAsync(response);
            await Task.Delay(TimeSpan.FromSeconds(1));
        }  
    }

}