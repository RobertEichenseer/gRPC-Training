# Create gRPC Server
Set-Location .\01\Start
dotnet new grpc -o DataServer

# Start Server
dotnet run --project .\DataServer\DataServer.csproj

# Test Server
# Open new PowerShell Terminal in VSCode
$listeningPort = 7017
Set-Location .\Tools\grpcurl\
.\grpcurl -proto ..\..\01\Start\DataServer\Protos\greet.proto -d '{\"name\": \"Robert\"}' localhost:$listeningPort greet.Greeter/SayHello

