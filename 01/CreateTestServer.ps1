# Please open a PowerShell terminal in VSCode 
# and ensure that you're in the project of the training folder  (e.g. C:\Training\GRPC-TRAINING\)
# You should see the folders like 01, 02, 03 ... .vscode in the directory

# Create gRPC Server
Set-Location .\01\Start
dotnet new grpc -o DataServer

# Start Server
dotnet run --project .\DataServer\DataServer.csproj

# Test Server
# Open new (!) PowerShell Terminal in VSCode
# Update $listeningPort with port number your gRPC server is listening
# The portnumber is listed in the TERMINAL window (e.g "info: Now listening on: https://localhost:XXXX")
$listeningPort = 7202
Set-Location .\Tools\grpcurl\
.\grpcurl -proto ..\..\01\Start\DataServer\Protos\greet.proto -d '{\"name\": \"Robert\"}' localhost:$listeningPort greet.Greeter/SayHello

