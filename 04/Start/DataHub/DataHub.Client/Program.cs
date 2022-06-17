using DataHub.ServiceDefinition; 
using Grpc.Net.Client; 

string serverAddress = "https://localhost:5001";
GrpcChannel grpcChannel = GrpcChannel.ForAddress(serverAddress);
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
